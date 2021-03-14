using PhillipsHueConsole.controller;
using System;
using System.Threading.Tasks;

namespace PhillipsHueConsole.model {
    class Program {

        private static Controller controller = Controller.GetInstance();

        static async Task Main() {
            await controller.InitializeData();
            var lights = controller.Lights;
            var groups = controller.Groups;
            var schedules = controller.Schedules;
            var scenes = controller.Scenes;

            //lights.ForEach(Console.WriteLine);
            //groups.ForEach(Console.WriteLine);
            //schedules.ForEach(Console.WriteLine);
            //scenes.ForEach(Console.WriteLine);

            //await controller.SetComponentState(groups[0], "bri", "120");
            //await controller.SetComponentState(groups[0], "on", "false");
            Console.ReadKey();
        }
    }
}
