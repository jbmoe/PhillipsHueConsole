using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using test.controller;
using test.model;

namespace test {
    class Program {

        private static Controller controller = Controller.GetInstance();

        static async Task Main() {
            await controller.InitializeData(); ;
            var lights = controller.Lights;
            var groups = controller.Groups;
            await controller.SetComponentState(groups[0], "bri", "254");
            await controller.SetComponentState(groups[0], "on", "false");
        }
    }
}
