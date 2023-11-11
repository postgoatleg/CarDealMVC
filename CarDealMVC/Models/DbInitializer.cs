using Azure;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CarDealMVC.Models
{
    public static class DbInitializer
    {
        public static void Initialize(CarDealerContext db)
        {
            db.Database.EnsureCreated();

            

            int cars_num = 100;
            int models_num = 20;
            int carcases_num = 6;
            int employees_num = 20;
            int manufactirers_num = 10;
            int positions_num = 5;
            int orders_num = 75;
            int equipments_num = 200;
            Random rand = new Random(1);

            string[] manufacturers_names = { "BMW, Германия", "Mersedes, Германия", "Audi, Германия", "Opel, Германия", "Jeely, Китай", "BYD, Китай", "Mitsubishi, Япония", "Nissan, Япония", "Toyota, Япония", "Tesla, США" };
            string[] positions_names = { "продавец", "консультант", "инженер", "уборщик", "экономист" };
            string[] clients_names = "Александр , Михаил , Максим , Лев , Артем , Марк , Матвей , Иван , Даниил , Дмитрий , Тимофей , Мирон , Роман , Мухаммад , Кирилл , Илья , Егор , Константин , Андрей , Алексей , Федор , Арсений , Владимир , Тимур , Никита".Split(" , ");
            string[] client_lastnames = "Смирнов\r\nИванов\r\nКузнецов\r\nСоколов\r\nПопов\r\nЛебедев\r\nКозлов\r\nНовиков\r\nМорозов\r\nПетров\r\nВолков\r\nСоловьёв\r\nВасильев\r\nЗайцев\r\nПавлов\r\nСемёнов\r\nГолубев\r\nВиноградов\r\nБогданов\r\nВоробьёв\r\nФёдоров\r\nМихайлов\r\nБеляев\r\nТарасов\r\nБелов".Split("\r\n");
            string[] carcases_names = { "универсал", "седан", "хэтчбэк", "купэ", "пикап", "внедорожник" };
            string[] carcases_descriptions = { "легковой автомобиль с самым вместительным багажником", "кузов с небольшим багажным проёмом", "компактный кузов, в который удобно грузить габаритные вещи", "двухдверный автомобиль", "Лёгкий автомобиль с открытой грузовой площадкой и задним откидным бортом", "заточен на езду вне асфальта" };
            string[] models_names = { "sport", "super", "v8", "turbo", "drift", "engine", "dream", "drain", "focus", "metro", "town", "defender", "aggresive", "extra", "hard", "easy" };
            string[] equip_names = "усилитель руля.\r\nКондиционер или климат-контроль.\r\nКруиз-контроль.\r\nПередние и задние электростеклоподъемники.\r\nЭлектрорегулировка боковых зеркал, а также привод их складывания.\r\nДисковые тормоза задних колес.\r\nДополнительная защита картера.\r\nЭлектрический стояночный тормоз.\r\nДатчик дождя и автоматические стеклоочистители.\r\nТонировка стекол.\r\nАтермальное (теплозащитное) остекление.\r\nЗапуск двигателя кнопкой.\r\nЭлектропривод крышки багажника.\r\nМультимедийная аудиосистема с навигацией.\r\nМультифункциональное рулевое колесо.\r\nДоводчики дверей.\r\nПанорамная крыша.\r\nЛюк с электроприводом. Регулировка руля по вылету и наклону.\r\nКожаная отделка руля и ручки рычага КПП.\r\nКожаная обивка сидений.\r\nПодлокотники для передних и задних сидений.\r\nЭлектрорегулировка передних сидений.\r\nПамять настроек сидений и зеркал.\r\nВентиляция передних сидений".Split(".\r\n");
            int equip_count = equip_names.Length;

            if (!db.ExtraEquipments.Any())
            {
                for (int i = 0; i < equip_count; i++)
                {
                    db.ExtraEquipments.Add(new ExtraEquipment { EquipmentName = equip_names[i], Price = rand.Next(100, 1000) });
                }
                db.SaveChanges();
            }

            if (!db.CarcaseTypes.Any())
            {
                for (int i = 0; i < carcases_num; i++)
                {
                    db.CarcaseTypes.Add(new CarcaseType { TypeName = carcases_names[i], TypeDescription = carcases_descriptions[i] });
                }
                db.SaveChanges();
            }

            if (!db.Positions.Any())
            {
                for (int i = 0; i < positions_num; i++)
                {
                    db.Positions.Add(new Position { PositionName = positions_names[i], Salary = rand.Next(1000, 5000) });
                }
                db.SaveChanges();
            }

            if (!db.Employees.Any())
            {
                for (int i = 0; i < employees_num; i++)
                {
                    db.Employees.Add(new Employee
                    {
                        FirstName = clients_names[rand.Next(clients_names.Length)],
                        LastName = client_lastnames[rand.Next(client_lastnames.Length)],
                        PositionId = rand.Next(positions_names.Length) + 1,
                        Age = rand.Next(18, 66)
                    });
                }
                db.SaveChanges();
            }

            if (!db.Manufacturers.Any())
            {
                string[] info;
                for (int i = 0; i < manufactirers_num; i++)
                {
                    info = manufacturers_names[i].Split(", ");
                    db.Manufacturers.Add(new Manufacturer
                    {
                        ManufacturerName = info[0],
                        Country = info[1],
                        ExtraDescription = $"Штаб-квартира {info[0]} находится в государстве {info[1]}.",
                        Adres = $"{info[1]}, {rand.Next(1, 100)}",

                    });
                }
                db.SaveChanges();
            }

            if (db.CarModels.Any())
            {
                string nm;
                for (int i = 0; i < models_num; i++)
                {
                    nm = $"{models_names[rand.Next(models_names.Length)]} {models_names[rand.Next(models_names.Length)]}";
                    db.CarModels.Add(new CarModel { ModelName = char.ToUpper(nm[0]) + nm.Substring(1) });
                }
                db.SaveChanges();
            }

            var ids = db.Employees.Where(e => e.PositionId == 1).Select(w => w.EmployeeId).ToList();
            Console.WriteLine(ids.Count);
            Debug.WriteLine(ids.Count);
            if (!db.Cars.Any())
            {
                for (int i = 0; i < cars_num; i++)
                {
                    var car = new Car
                    {
                        CarcaseTypeId = rand.Next(carcases_num) + 1,
                        CarsStats = $"Скорость - {rand.Next(200, 350)} км/ч. Разгон 0-100 - {rand.Next(2, 10)} секунды. Расход топлива - {rand.Next(5, 15)} литров на 100 км.",
                        ManufacturerId = rand.Next(manufactirers_num) + 1,
                        EngineNumber = "",
                        ModelId = rand.Next(models_num) + 1,
                        Price = rand.Next(10000, 100000),
                        RegistrationNumber = $"{rand.Next(1000, 10000)}AB-5",
                        ReleaseYear = new DateTime(rand.Next(1990, 2023), rand.Next(12) + 1, rand.Next(1, 28)),
                        SellerEmployeeId = ids[rand.Next(ids.Count)],
                        Color = Convert.ToString(rand.Next(16800000), 16),

                    };
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }

            if(!db.CarsEquipments.Any())
            {
                for (int i = 0; i < equipments_num; i++)
                {
                    db.CarsEquipments.Add(new CarsEquipment { CarId = rand.Next(cars_num-1) + 1, EquipmentId = rand.Next(equip_count-1) + 1 });
                }
                db.SaveChanges();
            }

            if(!db.Orders.Any())
            {
                DateTime dateTime;
                bool isPayed;
                for (int i = 0; i < orders_num; i++)
                {
                    isPayed = rand.NextDouble() > 0.5;
                    dateTime = new DateTime(2023, rand.Next(12) + 1, rand.Next(1, 28));
                    var order = new Order
                    {
                        Adres = $"Беларусь, {rand.Next(1, 10000)}",
                        CarId = rand.Next(cars_num) + 1,
                        Name = clients_names[rand.Next(clients_names.Length)],
                        Surname = client_lastnames[rand.Next(client_lastnames.Length)],
                        OrderDate = dateTime,
                        PassportData = $"HB{rand.Next(1000000, 10000000)}",
                        Telephone = $"+375{rand.NextInt64(100000000, 1000000000)}",
                        IsPayed = isPayed,
                    };
                    if (isPayed)
                    {
                        order.SaleDate = dateTime.AddDays(rand.NextDouble() * 15);
                    }
                    db.Orders.Add(order);
                }
                db.SaveChanges();
            }

        }

    }
}
