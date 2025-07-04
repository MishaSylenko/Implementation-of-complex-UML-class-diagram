// using BYT_03.entities;
// using BYT_03.entities.Abstract;
// using BYT_03.data;
// using BYT_03.entities.enums;
// using BYT_03.services;
//
// Storage.LoadData();
//
// var userService = new UserService();
// var itemService = new ItemService();
// var workerTaskService = new WorkerTaskService();
// var orderService = new OrderService();
// var reviewService = new ReviewService();
// var paymentService = new PaymentService();
//
//
// var items = new List<Item>
// {
//     new Computer
//     {
//         Name = "Gaming PC",
//         Price = 1500,
//         Brand = "BrandA",
//         Type = ComputerType.GAMING,
//         CableType = "TypeC",
//         Description = "Gaming PC",
//         Charging = true,
//         InStock = 10
//     },
//     new ComputerPart
//     {
//         Name = "Graphics Card",
//         Price = 700,
//         Brand = "BrandB",
//         CompatibleWith = "Gaming PC",
//         Description = "Graphics Card",
//         InStock = 15
//     },
//     new ComputerPart
//     {
//         Name = "RAM",
//         Price = 100,
//         Brand = "BrandX",
//         Description = "16GB DDR4",
//         InStock = 20,
//         CompatibleWith = "Gaming PC"
//     },
//     new PoweredComputerPart
//     {
//         Name = "Graphics Card",
//         Price = 400,
//         Brand = "BrandY",
//         Description = "NVIDIA RTX 3060",
//         CompatibleWith = "Gaming PC",
//         CableType = "TypeC",
//         Charging = false,
//     },
//     new BatteryPoweredComputerPart
//     {
//         Name = "Wireless Mouse",
//         Price = 50,
//         Brand = "BrandZ",
//         Description = "Bluetooth mouse",
//         BatteryType = "AA",
//         InStock = 24,
//         BatteriesQuantity = 2,
//         CompatibleWith = "Gaming PC"
//     }
// };
// // itemService.AddItems(items);
//
// Client user1 = new Client
// {
//     Name = "John",
//     Surname = "Doe",
//     Email = "test@c.com",
//     Phone = "123456789",
//     BirthDate = new DateOnly(1990, 1, 1),
//     Address = "Test address",
//     ShippingAddress = "Test shipping address",
// };
// user1.AddCard("1234 1234 1234 1234");
// user1.AddCard("4321 4321 4321 4321");
//
//
// // userService.AddUser(user1);
// // userService.AddUser(worker);
//
// Order order1 = new Order()
// {
//     Sum = 2200,
//     OrderStatus = OrderStatus.Placed,
//     ShippingAddress = "Test shipping address",
//     OrderShippingType = OrderShippingType.ParcelLocker,
// };
//
//
// order1.AttachUser((Client)userService.GetUserById(1));
//
// order1.AddItem(itemService.GetItemById(1), 1);
// order1.AddItem(itemService.GetItemById(2), 2);
// order1.AddItem(itemService.GetItemById(3), 2);
//
//
// orderService.AddOrder(order1);
//
// Payment payment1 = new Payment()
// {
//     Order = order1,
//     Date = new DateTime(2022, 1, 1),
//     PaymentMethod = PaymentMethod.Card
// };
// order1.SetPayment(payment1);
//
// // var task1 = new WorkerTask
// // {
// //     Name = "Task 1",
// //     Description = "Description 1",
// //     Deadline = new DateTime(2022, 1, 1, 12, 11, 10),
// //     Priority = 5,
// //     AttachedWorkersIds = [1],
// //     ItemsToRepair = []
// // };
// //
// // var task2 = new WorkerTask
// // {
// //     Name = "Task 2",
// //     Description = "Description 2",
// //     Deadline = new DateTime(2022, 1, 1, 12, 11, 10),
// //     Priority = 5,
// //     AttachedWorkersIds = [1],
// //     ItemsToRepair = [1, 2]
// // };
//
// // workerTaskService.AddWorkerTask(task1);
// // workerTaskService.AddWorkerTask(task2);
//
// foreach (var user in userService.GetAllUsers())
// {
//     Console.WriteLine(user.Value);
// }
//
//
// // foreach (var task in workerTaskService.GetAllWorkerTasks())
// // {
// //     Console.WriteLine(task.Value);
// // }

using BYT_03.entities;
using BYT_03.entities.Abstract;

Item item = new BatteryPoweredComputerPart();