using Newtonsoft.Json;
using PhillipsHueConsole.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhillipsHueConsole.controller {
    class Controller {
        #region singleton
        private static Controller _instance;
        public static Controller GetInstance() {
            if (_instance == null) {
                _instance = new Controller();
            }
            return _instance;
        }
        private Controller() { }
        #endregion
        #region network controller
        NetworkController networkController = NetworkController.GetInstance();
        #endregion
        #region data fields
        private List<Light> lights;
        private List<Group> groups;
        private List<Schedule> schedules;
        private List<Scene> scenes;
        #endregion
        #region data properties
        public List<Light> Lights { get { return lights; } }
        public List<Group> Groups { get { return groups; } }
        public List<Schedule> Schedules { get { return schedules; } }
        public List<Scene> Scenes { get { return scenes; } }
        #endregion

        public async Task<HttpResponseMessage> SetComponentState(HueComponent component, string property, string value) {
            // Check which type of component
            string requestUri = "";
            switch (component) {
                case Light:
                    requestUri = $"lights/{component.Key}/state";
                    break;
                case Group:
                    requestUri = $"groups/{component.Key}/action";
                    break;
            }

            // Send put request
            HttpContent content = new StringContent($"{{\"{property}\": {value}}}");
            HttpResponseMessage response = await networkController.Put(requestUri, content);

            return response;
        }


        #region initializer method
        public async Task InitializeData() {
            try {
                // initialize lights
                string responseLights = await networkController.Get("lights");
                Dictionary<string, Light> lightsIn = JsonConvert.DeserializeObject<Dictionary<string, Light>>(responseLights);
                InitializeKeyInObj(lightsIn);
                lights = lightsIn.Values.ToList();

                // initialize groups
                string responseGroups = await networkController.Get("groups");
                Dictionary<string, Group> groupsIn = JsonConvert.DeserializeObject<Dictionary<string, Group>>(responseGroups);
                InitializeKeyInObj(groupsIn);
                groups = groupsIn.Values.ToList();

                // initialize schedules
                string responseSchedules = await networkController.Get("schedules");
                Dictionary<string, Schedule> schedulesIn = JsonConvert.DeserializeObject<Dictionary<string, Schedule>>(responseSchedules);
                InitializeKeyInObj(schedulesIn);
                schedules = schedulesIn.Values.ToList();

                // initialize scenes
                string responseScenes = await networkController.Get("scenes");
                Dictionary<string, Scene> scenesIn = JsonConvert.DeserializeObject<Dictionary<string, Scene>>(responseScenes);
                InitializeKeyInObj(scenesIn);
                scenes = scenesIn.Values.ToList();

                // initialize lights for groups and scenes
                InitializeLights(groups, lights);
                InitializeLights(scenes, lights);

            } catch (HttpRequestException e) {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            void InitializeKeyInObj<T>(Dictionary<string, T> objs) where T : HueComponent {
                foreach (string key in objs.Keys) {
                    objs[key].Key = key;
                }
            }
            void InitializeLights<T>(List<T> components, List<Light> lights) where T : IHasLights {
                foreach (T component in components) {
                    List<Light> newLights = new();
                    foreach (string i in component.lightKeys) {
                        Light toAdd = lights.Find(e => e.Key.Equals(i));
                        newLights.Add(toAdd);
                    }
                    component.Lights = newLights;
                }
            }
        }
        #endregion
    }
}
