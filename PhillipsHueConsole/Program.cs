using System;
using System.Threading.Tasks;
using test.controller;

namespace test {
    class Program {

        private static Controller controller = Controller.GetInstance();

        static async Task Main() {
            await controller.InitializeData(); ;
            var lights = controller.Lights;
            var groups = controller.Groups;

            groups.ForEach(Console.WriteLine);
            //await controller.SetComponentState(groups[0], "bri", "120");
            //await controller.SetComponentState(groups[0], "on", "true");


        }
    }
}
