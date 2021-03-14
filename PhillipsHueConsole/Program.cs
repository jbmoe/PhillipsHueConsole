using System;
using System.Threading.Tasks;
using test.controller;
using test.model;

namespace test {
    class Program {

        private static Controller controller = Controller.GetInstance();

        static async Task Main() {
            await controller.InitializeData();
            var lights = controller.Lights;
            var groups = controller.Groups;

            lights.ForEach(e => Console.WriteLine(e.State.Component));
            groups.ForEach(e => Console.WriteLine(e.Action.Component));

            //await controller.SetComponentState(groups[0], "bri", "120");
            //await controller.SetComponentState(groups[0], "on", "false");
            Console.ReadKey();
        }
    }
}
