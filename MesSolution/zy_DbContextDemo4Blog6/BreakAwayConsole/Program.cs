using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Validation;

//QQ群：33353329
//blog：oppoic.cnblogs.com

namespace BreakAwayConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //不管模型有没有改变都生成新的数据库文件
            Database.SetInitializer(new DropCreateDatabaseAlways<DbContexts.DataAccess.BreakAwayContext>());
            //using (var context = new DbContexts.DataAccess.BreakAwayContext())
            //{
            //    context.Database.Initialize(true);
            //}

            //如果实体发生变化，就删除并重新生成数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContexts.DataAccess.BreakAwayContext>());

            //【初始化数据】
            Database.SetInitializer(new DbContexts.DataAccess.InitializeDBWithSeedData());

            //第一章：
            //PrintAllDestinations();   //如需重新生成测试数据：取消注释本方法和【初始化数据】方法
            //PrintAllDestinationsSorted();
            FindDestination();
            //PrintDestinationNameOnly();
            //TestFindLocalData();
            //TestGetNewAddedData();
            //GetLocalDestinationCountAfterCheckDB();
            //GetLocalDestinationCountWithLoad();
            //LocalLinqQueries();
            //ListenToLocalChanges();
            //TestLazyLoading();
            //TestEagerLoading();
            //TestExplicitLoading();
            //QueryLodgingDistance();
            //QueryLodgingDistancePro();
            //QueryLodgingCount();

            //第二章：
            //AddMachuPicchu();
            //GetGreatBarrierReef();
            //ChangeGrandCanyon();
            //DeleteWineGlassBay();
            //DeleteWineGlassBayAttach();
            //DeleteWineGlassBayExecuteSqlCommand();
            //NewGrandCanyonResort();
            //AddSingleAndRelatedData();
            //DeleteTrip();
            //DeleteTripLoadRelateData();
            //DeleteGrandCanyonAndMarkChildEntitiesDeletion();
            //DeleteGrandCanyonAndChangeChildEntitiesPrimaryKey();
            //LoadRelateData();
            //LoadPrimaryKeyData();
            //MakeMultipleChanges();
            //FindOrAddPerson();
            //ChangeLodgingDestination();
            //RemovePrimaryContactForeignKeys();
            //RemovePrimaryContactReference();

            //第三章
            //GetOneEntityToSeeEntityState();
            //TestAddDestination();
            //TestAttachDestination();
            //TestUpdateDestination();
            //TestDeleteDestination();
            //TestUpdateLodging();
            //AddSimpleGraph();
            //TestSaveDestinationAndLodgings();
            //TestSaveDestinationGraph();

            //第四章
            //PrintState();
            //PrintLodgingInfo();
            //PrintLodgingInfoAddAndDelete();
            //PrintOriginalName();
            //TestPrintDestination();
            //ChangeCurrentValue();
            //CloneCurrentValues();
            //UndoEdits();
            //CreateDavesCampsite();
            //WorkingWithPropertyMethod();
            //FindModifiedProperties();
            //WorkingWithReferenceMethod();
            //WorkingWithCollectionMethod();
            //ReloadLodging();
            //PrintChangeTrackerEntries();
            //ConcurrencyDemo();
            //TestSaveLogging();

            //第五章
            //ValidateNewPerson();
            //ValidateDestination();
            //ValidatePropertyOnDemand();
            //ValidateTrip();
            //ValidateEverything();

            //第六章
            //CreateDuplicateLodging();

            Console.WriteLine("ok");
            Console.ReadKey();
        }

        #region 第一章
        /// <summary>
        /// 查出所有景点
        /// </summary>
        private static void PrintAllDestinations()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        /// <summary>
        /// 按照名称排序
        /// </summary>
        private static void PrintAllDestinationsSorted()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            orderby d.Name
                            select d;

                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        /// <summary>
        /// 查出名称是Australia的景点
        /// </summary>
        private static void PrintAustralianDestinations()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            select d;

                foreach (var destination in query)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        /// <summary>
        /// 只取名称
        /// </summary>
        private static void PrintDestinationNameOnly()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                //linq写法
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            orderby d.Name
                            select d.Name;
                //C# Lambda表达式写法
                //var querys = context.Destinations
                //          .Where(d => d.Country == "Australia")
                //          .OrderBy(d => d.Name)
                //          .Select(d => d.Name);

                foreach (var name in query)
                {
                    Console.WriteLine(name);
                }
            }
        }

        /// <summary>
        /// Find方法查询数据库
        /// </summary>
        private static void FindDestination()
        {
            Console.Write("Enter id of Destination to find: ");
            var id = int.Parse(Console.ReadLine());
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var destination = context.Destinations.Find(id);

                if (destination == null)
                {
                    Console.WriteLine("Destination not found!");
                }
                else
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        /// <summary>
        /// 测试Find方法查询内存中的数据
        /// </summary>
        private static void TestFindLocalData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d;
                query.Load();   //加载名称为Great Barrier Reef的景点到内存中
                Console.WriteLine(context.Destinations.Local.Count);  //输出内存中的数据个数

                var destination = context.Destinations.Find(4);
                if (destination == null)
                    Console.WriteLine("Destination not found!");
                else
                    Console.WriteLine(destination.Name);
            }
        }

        /// <summary>
        /// 获取一个实体对象（Single）
        /// </summary>
        private static void FindGreatBarrierReefSingle()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d;

                var reef = query.Single();  //查不到记录或者多条记录就报错
                Console.WriteLine(reef.Description);
            }
        }

        /// <summary>
        /// 获取一个实体对象（SingleOrDefault）
        /// </summary>
        private static void FindGreatBarrierReefSingleOrDefault()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d;

                var reef = query.SingleOrDefault();

                if (reef == null)
                {
                    Console.WriteLine("Can't find the reef!");
                }
                else
                {
                    Console.WriteLine(reef.Description);
                }
            }
        }

        /// <summary>
        /// 查询本地数据
        /// </summary>
        private static void GetLocalDestinationCount()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destinations in memory: {0}", count);
            }
        }

        /// <summary>
        /// 测试查询新标记添加但是没被插入数据库的数据
        /// </summary>
        private static void TestGetNewAddedData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var destination = new DbContexts.Model.Destination
                {
                    Name = "bingmayong",
                    Country = "China",
                    Description = "too boring~~~~~~"
                };
                context.Destinations.Add(destination);   //标记添加新实体

                var query = from d in context.Destinations
                            where d.Name == "bingmayong"
                            select d;

                var reef = query.SingleOrDefault();   //查询Name是兵马俑的对象

                if (reef == null)
                    Console.WriteLine("Can't find the reef!");
                else
                    Console.WriteLine(reef.Description);

                context.SaveChanges();   //调用SaveChanges方法，添加才会被插入数据库
            }
        }

        /// <summary>
        /// 先加载数据库再查询本地数据
        /// </summary>
        private static void GetLocalDestinationCountAfterCheckDB()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                foreach (var destination in context.Destinations)
                {
                    Console.WriteLine(destination.Name);
                }
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destinations in memory: {0}", count);
            }
        }

        /// <summary>
        /// Load方法把数据加载到内存
        /// </summary>
        private static void GetLocalDestinationCountWithLoad()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Load();
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Destinations in memory: {0}", count);
            }
        }

        /// <summary>
        /// Load方法把数据加载到内存（LINQ写法）
        /// </summary>
        private static void LoadAustralianDestinations()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Country == "Australia"
                            select d;
                query.Load();
                var count = context.Destinations.Local.Count;
                Console.WriteLine("Aussie destinations in memory: {0}", count);
            }
        }

        /// <summary>
        /// 操作内存中的数据（输出多次，但是只查一次数据库）
        /// </summary>
        private static void LocalLinqQueries()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Load();
                var sortedDestinations = from d in context.Destinations.Local
                                         orderby d.Name
                                         select d;
                Console.WriteLine("All Destinations:");
                foreach (var destination in sortedDestinations)
                {
                    Console.WriteLine(destination.Name);
                }

                var aussieDestinations = from d in context.Destinations.Local
                                         where d.Country == "Australia"
                                         select d;
                Console.WriteLine();
                Console.WriteLine("Australian Destinations:");
                foreach (var destination in aussieDestinations)
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        /// <summary>
        /// 监控内存中数据的变化
        /// </summary>
        private static void ListenToLocalChanges()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Local.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                    {
                        foreach (DbContexts.Model.Destination item in args.NewItems)
                        {
                            Console.WriteLine("Added: " + item.Name);
                        }
                    }
                    if (args.OldItems != null)
                    {
                        foreach (DbContexts.Model.Destination item in args.OldItems)
                        {
                            Console.WriteLine("Removed: " + item.Name);
                        }
                    }
                };
                context.Destinations.Load();
            }
        }

        /// <summary>
        /// 延迟加载LazyLoading
        /// </summary>
        private static void TestLazyLoading()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                //context.Configuration.LazyLoadingEnabled = false;  //关闭延迟加载
                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.Single();

                Console.WriteLine("Grand Canyon Lodging:");
                if (canyon.Lodgings != null)
                {
                    foreach (var lodging in canyon.Lodgings)
                    {
                        Console.WriteLine(lodging.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 贪婪加载EagerLoading
        /// </summary>
        private static void TestEagerLoading()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var allDestinations = context.Destinations.Include(d => d.Lodgings);
                //var AustraliaDestination = context.Destinations.Include(d => d.Lodgings).Where(d => d.Country == "Australia");
                //context.Lodgings.Include(l => l.PrimaryContact.Photo);
                //context.Destinations.Include(d => d.Lodgings.Select(l => l.PrimaryContact));
                //context.Lodgings.Include(l => l.PrimaryContact).Include(l => l.SecondaryContact);
                foreach (var destination in allDestinations)
                {
                    Console.WriteLine(destination.Name);
                    foreach (var lodging in destination.Lodgings)
                    {
                        Console.WriteLine(" - " + lodging.Name);
                    }
                }
            }
        }

        /// <summary>
        /// 显示加载ExplicitLoading
        /// </summary>
        private static void TestExplicitLoading()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var query = from d in context.Destinations
                            where d.Name == "Grand Canyon"
                            select d;

                var canyon = query.Single();
                context.Entry(canyon)
                  .Collection(d => d.Lodgings)
                  .Load();

                Console.WriteLine("Grand Canyon Lodging:");
                foreach (var lodging in canyon.Lodgings)
                {
                    Console.WriteLine(lodging.Name);
                }
            }
        }

        /// <summary>
        /// IsLoaded方法判断数据是否加载
        /// </summary>
        private static void TestIsLoaded()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                var entry = context.Entry(canyon);
                Console.WriteLine("Before Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);

                entry.Collection(d => d.Lodgings).Load();
                Console.WriteLine("After Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);
            }
        }

        /// <summary>
        /// 在内存中操作
        /// </summary>
        private static void QueryLodgingDistance()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;
                var canyon = canyonQuery.Single();
                var distanceQuery = from l in canyon.Lodgings
                                    where l.MilesFromNearestAirport <= 10
                                    select l;
                foreach (var lodging in distanceQuery)
                {
                    Console.WriteLine(lodging.Name);
                }
            }
        }

        /// <summary>
        /// 改进：在数据库中操作
        /// </summary>
        private static void QueryLodgingDistancePro()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;
                var canyon = canyonQuery.Single();
                var lodgingQuery = context.Entry(canyon).Collection(d => d.Lodgings).Query();
                var distanceQuery = from l in lodgingQuery
                                    where l.MilesFromNearestAirport <= 10
                                    select l;
                foreach (var lodging in distanceQuery)
                {
                    Console.WriteLine(lodging.Name);
                }
            }
        }

        /// <summary>
        /// 查询个数
        /// </summary>
        private static void QueryLodgingCount()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyonQuery = from d in context.Destinations
                                  where d.Name == "Grand Canyon"
                                  select d;
                var canyon = canyonQuery.Single();
                var lodgingQuery = context.Entry(canyon)
                  .Collection(d => d.Lodgings)
                  .Query();
                var lodgingCount = lodgingQuery.Count();
                Console.WriteLine("Lodging at Grand Canyon: " + lodgingCount);

                //context.Entry(canyon).Collection(d => d.Lodgings).Query().Where(l => l.Name.Contains("Hotel")).Load();
            }
        }
        #endregion

        #region 第二章
        /// <summary>
        /// 增加单个实体
        /// </summary>
        private static void AddMachuPicchu()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var mauchuPicchu = new DbContexts.Model.Destination
                {
                    Name = "Machu Picchu",
                    Country = "Peru"
                };
                context.Destinations.Add(mauchuPicchu);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        private static void GetGreatBarrierReef()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var destination = context.Destinations.Find(4);
                Console.WriteLine(destination.Name);
            }
        }

        /// <summary>
        /// 修改单个实体
        /// </summary>
        private static void ChangeGrandCanyon()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();
                canyon.Description = "227 mile long canyon.";
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        private static void DeleteWineGlassBay()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var bay = (from d in context.Destinations
                           where d.Name == "Wine Glass Bay"
                           select d).Single();

                context.Destinations.Remove(bay);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除单个实体attach
        /// </summary>
        private static void DeleteWineGlassBayAttach()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var toDelete = new DbContexts.Model.Destination { DestinationId = 2 };
                context.Destinations.Attach(toDelete);  //attach方法让EF知道这个实体

                context.Destinations.Remove(toDelete);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除单个实体ExecuteSqlCommand
        /// </summary>
        private static void DeleteWineGlassBayExecuteSqlCommand()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Database.ExecuteSqlCommand("delete from baga.Locations where LocationName = 'Hawaii'");
            }
        }

        /// <summary>
        /// 添加从表数据
        /// </summary>
        private static void NewGrandCanyonResort()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var resort = new DbContexts.Model.Resort
                {
                    Name = "Pete's Luxury Resort"
                };
                context.Lodgings.Add(resort);

                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();
                canyon.Lodgings.Add(resort);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// 添加主表数据同时添加相关联的从表数据
        /// </summary>
        private static void AddSingleAndRelatedData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var destination = new DbContexts.Model.Destination
                {
                    Name = "AnHui HuangShan",
                    Lodgings = new List<DbContexts.Model.Lodging>
                    { 
                        new DbContexts.Model.Lodging {Name="HuangShan Hotel"},
                        new DbContexts.Model.Lodging {Name="YingKeSong Hotel"}
                    }
                };
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 不加载从表数据直接删除主表数据（方法会报错）
        /// </summary>
        private static void DeleteTrip()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var trip = (from t in context.Trip
                            where t.Description == "Trip from the database"
                            select t).Single();

                context.Trip.Remove(trip);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 同时加载从表数据
        /// </summary>
        private static void DeleteTripLoadRelateData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var trip = (from t in context.Trip
                            where t.Description == "Trip from the database"
                            select t).Single();

                var res = (from r in context.Reservations
                           where r.Trip.Description == "Trip from the database"
                           select r).Single();

                context.Trip.Remove(trip);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 显示加载从表数据
        /// </summary>
        private static void DeleteGrandCanyonLoadRelateData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                context.Entry(canyon).Collection(d => d.Lodgings).Load();  //显示加载
                //不调用Load，也可以先调用Query方法，在内存中执行需要的操作再把结果集加载到内存中，效率！比如：
                //context.Entry(canyon).Collection(d => d.Lodgings).Query().Where(l => l.Name.Contains("Hotel")).Load();
                context.Destinations.Remove(canyon);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 级联删除：不加载从表数据（数据库里必须设置是级联删除）
        /// </summary>
        private static void DeleteGrandCanyonWithoutLoadRelateData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                context.Destinations.Remove(canyon);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 普通删除：删除主表数据，同时标注从表数据为删除状态（数据库关闭了级联删除的情况，可以手动去数据库的外键关系修改，也可以Fluent API配置关闭级联删除）
        /// </summary>
        private static void DeleteGrandCanyonAndMarkChildEntitiesDeletion()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                foreach (var lodging in canyon.Lodgings.ToList())
                {
                    context.Lodgings.Remove(lodging);   //先标记相关的从表数据为删除状态
                }
                context.Destinations.Remove(canyon);    //再标记主表数据为删除装填
                context.SaveChanges();   //执行上面的所有标记
            }
        }

        /// <summary>
        /// 普通删除：删除主表数据，同时设置从表数据指向另一个主键（数据库默认打开关闭级联删除都可以）
        /// </summary>
        private static void DeleteGrandCanyonAndChangeChildEntitiesPrimaryKey()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                //找到要删除的主表数据
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                //找到和主表数据相关的从表数据并修改其主键值，让这些相关的从表数据指向另一个存在的主表数据
                var hawaii = context.Destinations.Find(2);   //hawaii此时在数据库的主键是2（find方法生成的sql稍复杂，建议使用下面的普通写法）
                //var hawaii = (from d in context.Destinations
                //              where d.DestinationId == 2
                //              select d).Single();

                foreach (var lodging in canyon.Lodgings.ToList())
                {
                    lodging.Destination = hawaii;
                }

                //最后删除主表数据，可以此时只是单独的删除主表数据，它已经没有了相关的从表数据了
                context.Destinations.Remove(canyon);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 根据主表找从表数据（显示加载）
        /// </summary>
        private static void LoadRelateData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                context.Entry(canyon).Collection(d => d.Lodgings).Load();  //显示加载

                foreach (var lodging in context.Lodgings.Local)   //遍历的是内存中Lodgings的数据
                {
                    Console.WriteLine(lodging.Name);
                }
            }
        }

        /// <summary>
        /// 根据从表找主表数据（显示加载）
        /// </summary>
        private static void LoadPrimaryKeyData()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var lodging = context.Lodgings.First();
                //context.Entry(lodging).Reference(l => l.PrimaryContact).Load();
                context.Entry(lodging).Reference(l => l.Destination).Load();

                foreach (var destination in context.Destinations.Local)   //遍历的是内存中的Destinations数据
                {
                    Console.WriteLine(destination.Name);
                }
            }
        }

        /// <summary>
        /// 一次提交多个修改
        /// </summary>
        private static void MakeMultipleChanges()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var niagaraFalls = new DbContexts.Model.Destination
                {
                    Name = "Niagara Falls",
                    Country = "USA"
                };
                context.Destinations.Add(niagaraFalls);
                var wineGlassBay = (from d in context.Destinations
                                    where d.Name == "Wine Glass Bay"
                                    select d).Single();
                wineGlassBay.Description = "Picturesque bay with beaches";
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 有就查询，没有就添加并查询（通过EF获取自增长的主键id）
        /// </summary>
        private static void FindOrAddPerson()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var ssn = 123456789;
                var person = context.People.Find(ssn) ?? context.People.Add(new DbContexts.Model.Person
                {
                    SocialSecurityNumber = ssn,
                    FirstName = "Phelps",
                    LastName = "Michael"
                });
                Console.WriteLine(person.FirstName);
            }
        }

        /// <summary>
        /// 修改从表的外键
        /// </summary>
        private static void ChangeLodgingDestination()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from l in context.Lodgings
                             where l.Name == "Grand Hotel"
                             select l).Single();
                var reef = (from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d).Single();

                hotel.Destination = reef;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除主从表关系（ForeignKeys方式）
        /// </summary>
        private static void RemovePrimaryContactForeignKeys()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var davesDump = (from l in context.Lodgings
                                 where l.Name == "Dave's Dump"
                                 select l).Single();
                davesDump.PrimaryContactId = null;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除主从表关系（Reference方式）
        /// </summary>
        private static void RemovePrimaryContactReference()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var davesDump = (from l in context.Lodgings
                                 where l.Name == "Dave's Dump"
                                 select l).Single();
                context.Entry(davesDump).Reference(l => l.PrimaryContact).Load();  //找主表数据
                davesDump.PrimaryContact = null;  //清空
                context.SaveChanges();
            }
        }
        #endregion

        #region 第三章
        /// <summary>
        /// 查看实体状态
        /// </summary>
        private static void GetOneEntityToSeeEntityState()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var destination = context.Destinations.Find(4);
                EntityState stateBefore = context.Entry(destination).State;
                Console.WriteLine(stateBefore);
            }
        }

        /// <summary>
        /// 添加：DbSet.Add = > EntityState.Added
        /// </summary>
        private static void TestAddDestination()
        {
            var jacksonHole = new DbContexts.Model.Destination
            {
                Name = "Jackson Hole,Wyoming",
                Description = "Get your skis on."
            };
            //AddDestinationByDbSetAdd(jacksonHole);
            AddDestinationByEntityStateAdded(jacksonHole);
        }
        private static void AddDestinationByDbSetAdd(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }
        private static void AddDestinationByEntityStateAdded(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                Console.WriteLine(context.Entry(destination).State);    //添加前：Detached
                context.Entry(destination).State = EntityState.Added;
                Console.WriteLine(context.Entry(destination).State);    //添加后：Added
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 标记一个未改变的实体
        /// </summary>
        private static void TestAttachDestination()
        {
            DbContexts.Model.Destination canyon;
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d).Single();
            }
            AttachDestination(canyon);
        }
        private static void AttachDestination(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                Console.WriteLine(context.Entry(destination).State);    //标记前：Detached
                context.Destinations.Attach(destination);  //修改使用Attach方法
                //context.Entry(destination).State = EntityState.Unchanged;   //跟Attach方法一样效果
                Console.WriteLine(context.Entry(destination).State);    //标记后：Unchanged
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 修改：EntityState.Modified
        /// </summary>
        private static void TestUpdateDestination()
        {
            DbContexts.Model.Destination canyon;
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d).Single();
            }
            canyon.TravelWarnings = "Don't Fall in!";
            UpdateDestination(canyon);
        }
        private static void UpdateDestination(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                Console.WriteLine(context.Entry(destination).State);    //修改前：Detached
                context.Entry(destination).State = EntityState.Modified;
                Console.WriteLine(context.Entry(destination).State);    //修改后：Modified
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除：DbSet.Remove = > EntityState.Deleted
        /// </summary>
        private static void TestDeleteDestination()
        {
            DbContexts.Model.Destination canyon;
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                canyon = (from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d).Single();
            }
            //DeleteDestination(canyon);
            DeleteDestinationByEntityStateDeletion(canyon);
        }
        private static void DeleteDestination(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Attach(destination);  //先告诉EF这个实体
                context.Destinations.Remove(destination);  //执行删除
                context.SaveChanges();
            }
        }
        private static void DeleteDestinationByEntityStateDeletion(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                Console.WriteLine(context.Entry(destination).State);    //删除前：Detached
                context.Entry(destination).State = EntityState.Deleted;
                Console.WriteLine(context.Entry(destination).State);    //删除后：Deleted
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 修改外键值（有主外键关系时）
        /// </summary>
        private static void TestUpdateLodging()
        {
            int reefId;
            DbContexts.Model.Lodging davesDump;
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                reefId = (from d in context.Destinations
                          where d.Name == "Great Barrier Reef"
                          select d.DestinationId).Single();
                davesDump = (from l in context.Lodgings
                             where l.Name == "Dave's Dump"
                             select l).Single();
            }
            davesDump.DestinationId = reefId;
            UpdateLodging(davesDump);
        }
        private static void UpdateLodging(DbContexts.Model.Lodging lodging)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Entry(lodging).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 修改外键值（无主外键关系）
        /// </summary>
        private static void UpdateLodgingWithoutForeignKeys(DbContexts.Model.Lodging lodging, DbContexts.Model.Destination previousDestination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Entry(lodging).State = EntityState.Modified;
                context.Entry(lodging.Destination).State = EntityState.Unchanged;

                if (lodging.Destination.DestinationId != previousDestination.DestinationId)
                {
                    context.Entry(previousDestination).State = EntityState.Unchanged;
                    ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                        lodging,
                        lodging.Destination,
                        l => l.Destination,
                        EntityState.Added);
                    ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                        lodging,
                        previousDestination,
                        l => l.Destination,
                        EntityState.Deleted);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 添加一组数据（主从表）
        /// </summary>
        private static void AddSimpleGraph()
        {
            var essex = new DbContexts.Model.Destination
            {
                Name = "Essex, Vermont",
                Lodgings = new List<DbContexts.Model.Lodging>
                {
                    new DbContexts.Model.Lodging{Name="Big Essex Hotel"},
                    new DbContexts.Model.Lodging{Name="Essex Junction B&B"}
                }
            };
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Add(essex);
                Console.WriteLine("Essex Destination：{0}", context.Entry(essex).State);
                foreach (var lodging in essex.Lodgings)
                {
                    Console.WriteLine("{0}：{1}", lodging.Name, context.Entry(lodging).State);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 复杂的添加和删除
        /// </summary>
        private static void TestSaveDestinationAndLodgings()
        {
            DbContexts.Model.Destination canyon;
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                canyon = (from d in context.Destinations.Include(d => d.Lodgings)
                          where d.Name == "Grand Canyon"
                          select d).Single();
            }//查询【第一段sql】
            canyon.TravelWarnings = "Carry enough water!";//修改【第二段sql】
            canyon.Lodgings.Add(new DbContexts.Model.Lodging { Name = "Big Canyon Lodge" });//增加【第三段sql】

            var firstLodging = canyon.Lodgings.ElementAt(0);
            firstLodging.Name = "New Name Holiday Park";//修改【第四段sql】
            var secondLodging = canyon.Lodgings.ElementAt(1);
            var deletedLodgings = new List<DbContexts.Model.Lodging>();
            canyon.Lodgings.Remove(secondLodging);//删除【第五段sql】
            deletedLodgings.Add(secondLodging);

            SaveDestinationAndLodgings(canyon, deletedLodgings);
        }

        /// <summary>
        /// 设置每一个实体状态保证正确的提交修改
        /// </summary>
        /// <param name="destination">要添加的实体</param>
        /// <param name="deteledLodgings">要删除的实体</param>
        private static void SaveDestinationAndLodgings(DbContexts.Model.Destination destination, List<DbContexts.Model.Lodging> deteledLodgings)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Add(destination);

                if (destination.DestinationId > 0)  //避免了新添加的实体
                    context.Entry(destination).State = EntityState.Modified;
                foreach (var lodging in destination.Lodgings)
                {
                    if (lodging.LodgingId > 0)
                        context.Entry(lodging).State = EntityState.Modified;
                }
                foreach (var lodging in deteledLodgings)
                {
                    context.Entry(lodging).State = EntityState.Deleted;
                }
                //看看每个实体的状态
                Console.WriteLine("{0}：{1}", destination.Name, context.Entry(destination).State);
                foreach (var lodging in destination.Lodgings)
                {
                    Console.WriteLine("{0}：{1}", lodging.Name, context.Entry(lodging).State);
                }
                foreach (var lodging in deteledLodgings)
                {
                    Console.WriteLine("{0}：{1}", lodging.Name, context.Entry(lodging).State);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 设置实体的状态为自定义的枚举值，然后统一跟踪
        /// </summary>
        public static void SaveDestinationGraph(DbContexts.Model.Destination destination)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Destinations.Add(destination);
                foreach (var entry in context.ChangeTracker.Entries<DbContexts.Model.IObjectWithState>())
                {
                    DbContexts.Model.IObjectWithState stateInfo = entry.Entity;
                    entry.State = ConvertState(stateInfo.State);
                }
                context.SaveChanges();
            }
        }
        public static EntityState ConvertState(DbContexts.Model.State state)
        {
            switch (state)
            {
                case DbContexts.Model.State.Added:
                    return EntityState.Added;
                case DbContexts.Model.State.Deleted:
                    return EntityState.Deleted;
                case DbContexts.Model.State.Modified:
                    return EntityState.Modified;
                default:
                    return EntityState.Unchanged;
            }
        }
        private static void TestSaveDestinationGraph()
        {
            DbContexts.Model.Destination canyon;
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                canyon = (from d in context.Destinations.Include(d => d.Lodgings)
                          where d.Name == "Grand Canyon"
                          select d).Single();
            }
            canyon.TravelWarnings = "Carry enough water!";
            canyon.State = DbContexts.Model.State.Modified;  //设置为我们自定义的枚举，跟EF的EntityState没关系

            var firstLodging = canyon.Lodgings.First();
            firstLodging.Name = "New Name Holiday Park";
            firstLodging.State = DbContexts.Model.State.Modified;  //设置为我们自定义的枚举

            var secondLodging = canyon.Lodgings.Last();
            secondLodging.State = DbContexts.Model.State.Deleted;  //设置为我们自定义的枚举

            canyon.Lodgings.Add(new DbContexts.Model.Lodging
            {
                Name = "Big Canyon Lodge",
                State = DbContexts.Model.State.Added    //设置为我们自定义的枚举
            });

            //SaveDestinationGraph(canyon);
            ApplyChanges(canyon);   //通用方法
        }

        /// <summary>
        /// 通用的转换实体状态方法
        /// </summary>
        /// <typeparam name="TEntity">要操作的实体</typeparam>
        /// <param name="root">根实体</param>
        private static void ApplyChanges<TEntity>(TEntity root) where TEntity : class, DbContexts.Model.IObjectWithState
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                context.Set<TEntity>().Add(root);
                CheckForEntitiesWithoutStateInterface(context);   //检查
                foreach (var entry in context.ChangeTracker.Entries<DbContexts.Model.IObjectWithState>())
                {
                    DbContexts.Model.IObjectWithState stateInfo = entry.Entity;
                    entry.State = ConvertState(stateInfo.State);
                }
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 检查实体是否实现了IObjectWithState接口
        /// </summary>
        private static void CheckForEntitiesWithoutStateInterface(DbContexts.DataAccess.BreakAwayContext context)
        {
            var entitiesWithoutState = from e in context.ChangeTracker.Entries()
                                       where !(e.Entity is DbContexts.Model.IObjectWithState)
                                       select e;
            if (entitiesWithoutState.Any())
                throw new NotSupportedException("All entities must implement IObjectWithState");
        }
        #endregion

        #region 第四章
        /// <summary>
        /// 单个实体的状态
        /// </summary>
        private static void PrintState()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();
                DbEntityEntry<DbContexts.Model.Destination> entry = context.Entry(canyon);
                Console.WriteLine("Before Edit：{0}", entry.State);   //Unchaged

                canyon.TravelWarnings = "Take a lot of Water!";
                DbEntityEntry<DbContexts.Model.Destination> entrys = context.Entry(canyon);
                Console.WriteLine("After Edit：{0}", entrys.State);   //Modified
            }
        }

        /// <summary>
        /// 打印实体当前、原始和数据库值
        /// </summary>
        private static void PrintLodgingInfo()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from d in context.Lodgings
                             where d.Name == "Grand Hotel"
                             select d).Single();
                hotel.Name = "Super Grand Hotel";
                context.Database.ExecuteSqlCommand(@"UPDATE Lodgings SET Name = 'Not-So-Grand Hotel' WHERE Name = 'Grand Hotel'");
                PrintChangeTrackingInfo(context, hotel);
            }
        }
        private static void PrintChangeTrackingInfo(DbContexts.DataAccess.BreakAwayContext context, DbContexts.Model.Lodging entity)
        {
            var entry = context.Entry(entity);
            Console.WriteLine(entry.Entity.Name);
            Console.WriteLine("State: {0}", entry.State);

            if (entry.State != EntityState.Deleted)   //标记删除的实体不会有当前值
            {
                Console.WriteLine("\nCurrent Values:");
                PrintPropertyValues(entry.CurrentValues);
            }
            if (entry.State != EntityState.Added)   //新添加的时候不会有原始值和数据库值
            {
                Console.WriteLine("\nOriginal Values:");
                PrintPropertyValues(entry.OriginalValues);
                Console.WriteLine("\nDatabase Values:");
                PrintPropertyValues(entry.GetDatabaseValues());
            }
        }
        private static void PrintPropertyValues(DbPropertyValues values)
        {
            foreach (var propertyName in values.PropertyNames)
            {
                Console.WriteLine(" - {0}: {1}", propertyName, values[propertyName]);
            }
        }

        /// <summary>
        /// 测试打印添加和删除时实体当前、原始和数据库值
        /// </summary>
        private static void PrintLodgingInfoAddAndDelete()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from d in context.Lodgings
                             where d.Name == "Grand Hotel"
                             select d).Single();
                PrintChangeTrackingInfo(context, hotel);   //默认

                var davesDump = (from d in context.Lodgings
                                 where d.Name == "Dave's Dump"
                                 select d).Single();
                context.Lodgings.Remove(davesDump);
                PrintChangeTrackingInfo(context, davesDump);   //测试删除实体

                var newMotel = new DbContexts.Model.Lodging { Name = "New Motel" };
                context.Lodgings.Add(newMotel);
                PrintChangeTrackingInfo(context, newMotel);  //测试新添加实体
            }
        }

        /// <summary>
        /// 通用的打印实体方法
        /// </summary>
        private static void PrintChangeTrackingInfo(DbContexts.DataAccess.BreakAwayContext context, object entity)
        {
            var entry = context.Entry(entity);
            Console.WriteLine("Type：{0}", entry.Entity.GetType());   //打印实体类型
            Console.WriteLine("State: {0}", entry.State);

            if (entry.State != EntityState.Deleted)   //标记删除的实体不会有当前值
            {
                Console.WriteLine("\nCurrent Values:");
                PrintPropertyValues(entry.CurrentValues);
            }
            if (entry.State != EntityState.Added)   //新添加的时候不会有原始值和数据库值
            {
                Console.WriteLine("\nOriginal Values:");
                PrintPropertyValues(entry.OriginalValues);
                Console.WriteLine("\nDatabase Values:");
                PrintPropertyValues(entry.GetDatabaseValues());
            }
        }

        /// <summary>
        /// 打印实体单个属性
        /// </summary>
        private static void PrintOriginalName()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from d in context.Lodgings
                             where d.Name == "Grand Hotel"
                             select d).Single();
                hotel.Name = "Super Grand Hotel";
                string originalName = context.Entry(hotel).OriginalValues.GetValue<string>("Name");

                Console.WriteLine("Current Name: {0}", hotel.Name);  //Super Grand Hotel
                Console.WriteLine("Original Name: {0}", originalName);  //Grand Hotel
            }
        }

        /// <summary>
        /// 拷贝实体属性：ToObject方法
        /// </summary>
        private static void PrintDestination(DbContexts.Model.Destination destination)
        {
            Console.WriteLine("-- {0}, {1} --", destination.Name, destination.Country);
            Console.WriteLine(destination.Description);
            if (destination.TravelWarnings != null)
            {
                Console.WriteLine("WARNINGS!: {0}", destination.TravelWarnings);
            }
        }
        private static void TestPrintDestination()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var reef = (from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d).Single();
                reef.TravelWarnings = "Watch out for sharks!";
                Console.WriteLine("Current Values");
                PrintDestination(reef);

                Console.WriteLine("\nDatabase Values");
                DbPropertyValues dbValues = context.Entry(reef).GetDatabaseValues();
                PrintDestination((DbContexts.Model.Destination)dbValues.ToObject());  //ToObject方法创建Destination实例
            }
        }

        /// <summary>
        /// 修改DbPropertyValues当前值
        /// </summary>
        private static void ChangeCurrentValue()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from d in context.Lodgings
                             where d.Name == "Grand Hotel"
                             select d).Single();
                context.Entry(hotel).CurrentValues["Name"] = "Hotel Pretentious";
                Console.WriteLine("Property Value: {0}", hotel.Name);
                Console.WriteLine("State: {0}", context.Entry(hotel).State);  //Modified
            }
        }

        /// <summary>
        /// 克隆实体：Clone
        /// </summary>
        private static void CloneCurrentValues()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from d in context.Lodgings
                             where d.Name == "Grand Hotel"
                             select d).Single();
                var values = context.Entry(hotel).CurrentValues.Clone();  //Clone方法
                values["Name"] = "Simple Hotel";
                Console.WriteLine("Property Value: {0}", hotel.Name);
                Console.WriteLine("State: {0}", context.Entry(hotel).State);  //Unchanged
            }
        }

        /// <summary>
        /// 设置实体的值：SetValues方法
        /// </summary>
        private static void UndoEdits()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();

                canyon.Name = "Bigger & Better Canyon";

                var entry = context.Entry(canyon);
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;  //标记未修改

                Console.WriteLine("Name: {0}", canyon.Name);  //Grand Canyon
            }
        }

        /// <summary>
        /// 克隆实体：SetValues
        /// </summary>
        private static void CreateDavesCampsite()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var davesDump = (from d in context.Lodgings
                                 where d.Name == "Dave's Dump"
                                 select d).Single();
                var clone = new DbContexts.Model.Lodging();
                context.Lodgings.Add(clone);

                context.Entry(clone).CurrentValues.SetValues(davesDump);  //克隆davesDump的值到新对象clone里
                clone.Name = "Dave's Camp";  //修改Name属性
                context.SaveChanges();  //最后提交修改

                Console.WriteLine("Name: {0}", clone.Name);  //Dave's Camp
                Console.WriteLine("Miles: {0}", clone.MilesFromNearestAirport);  //32.65
                Console.WriteLine("Contact Id: {0}", clone.PrimaryContactId);  //1
            }
        }

        /// <summary>
        /// 获取和设置实体的单个属性：Property方法
        /// </summary>
        private static void WorkingWithPropertyMethod()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var davesDump = (from d in context.Lodgings
                                 where d.Name == "Dave's Dump"
                                 select d).Single();
                var entry = context.Entry(davesDump);
                entry.Property(d => d.Name).CurrentValue = "Dave's Bargain Bungalows";  //设置Name属性

                Console.WriteLine("Current Value: {0}", entry.Property(d => d.Name).CurrentValue);  //Dave's Bargain Bungalows
                Console.WriteLine("Original Value: {0}", entry.Property(d => d.Name).OriginalValue);  //Dave's Dump
                Console.WriteLine("Modified？: {0}", entry.Property(d => d.Name).IsModified);   //True
            }
        }

        /// <summary>
        /// 查询实体被修改属性：IsModified方法
        /// </summary>
        private static void FindModifiedProperties()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();
                canyon.Name = "Super-Size Canyon";
                canyon.TravelWarnings = "Bigger than your brain can handle!!!";
                var entry = context.Entry(canyon);
                var propertyNames = entry.CurrentValues.PropertyNames;  //获取所有的Name列

                IEnumerable<string> modifiedProperties = from name in propertyNames
                                                         where entry.Property(name).IsModified
                                                         select name;

                foreach (var propertyName in modifiedProperties)
                {
                    Console.WriteLine(propertyName);  //Name、TravelWarnings
                }
            }
        }

        /// <summary>
        /// 修改导航属性（Reference）：CurrentValue方法
        /// </summary>
        private static void WorkingWithReferenceMethod()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var davesDump = (from d in context.Lodgings
                                 where d.Name == "Dave's Dump"
                                 select d).Single();
                var entry = context.Entry(davesDump);
                entry.Reference(l => l.Destination).Load();   //显示加载

                var canyon = davesDump.Destination;
                Console.WriteLine("Current Value After Load: {0}", entry.Reference(d => d.Destination).CurrentValue.Name);

                var reef = (from d in context.Destinations
                            where d.Name == "Great Barrier Reef"
                            select d).Single();
                entry.Reference(d => d.Destination).CurrentValue = reef;   //修改
                Console.WriteLine("Current Value After Change: {0}", davesDump.Destination.Name);
            }
        }

        /// <summary>
        /// 修改导航属性（Collection）：CurrentValue方法
        /// </summary>
        private static void WorkingWithCollectionMethod()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var res = (from r in context.Reservations
                           where r.Trip.Description == "Trip from the database"
                           select r).Single();
                var entry = context.Entry(res);
                entry.Collection(r => r.Payments).Load();
                Console.WriteLine("Payments Before Add: {0}", entry.Collection(r => r.Payments).CurrentValue.Count);

                var payment = new DbContexts.Model.Payment { Amount = 245 };
                context.Payments.Add(payment);
                entry.Collection(r => r.Payments).CurrentValue.Add(payment);  //修改
                Console.WriteLine("Payments After Add: {0}", entry.Collection(r => r.Payments).CurrentValue.Count);
            }
        }

        /// <summary>
        /// 取当前最新的数据库值：Reload方法
        /// </summary>
        private static void ReloadLodging()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var hotel = (from d in context.Lodgings
                             where d.Name == "Grand Hotel"
                             select d).Single();  //取出实体
                hotel.Name = "A New Name";  //修改
                context.Database.ExecuteSqlCommand(@"UPDATE dbo.Lodgings SET Name = 'Le Grand Hotel' WHERE Name = 'Grand Hotel'");   //立马修改实体值（这个时候数据库中的值已改变，但是取出来放在内存中的值并没改变）
                Console.WriteLine("Name Before Reload: {0}", hotel.Name);
                Console.WriteLine("State Before Reload: {0}", context.Entry(hotel).State);

                context.Entry(hotel).Reload();
                Console.WriteLine("Name After Reload: {0}", hotel.Name);
                Console.WriteLine("State After Reload: {0}", context.Entry(hotel).State);
            }
        }

        /// <summary>
        /// 读取相关联的实体和状态：DbContext.ChangeTracker.Entries方法
        /// </summary>
        private static void PrintChangeTrackerEntries()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var res = (from r in context.Reservations
                           where r.Trip.Description == "Trip from the database"
                           select r).Single();

                context.Entry(res).Collection(r => r.Payments).Load();
                res.Payments.Add(new DbContexts.Model.Payment { Amount = 245 });
                var entries = context.ChangeTracker.Entries();

                foreach (var entry in entries)
                {
                    Console.WriteLine("Entity Type: {0}", entry.Entity.GetType());
                    Console.WriteLine(" - State: {0}", entry.State);
                }
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        private static void ConcurrencyDemo()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var trip = (from t in context.Trip.Include(t => t.Destination)
                            where t.Description == "Trip from the database"
                            select t).Single();
                trip.Description = "Getaway in Vermont";
                context.Database.ExecuteSqlCommand(@"UPDATE dbo.Trips SET CostUSD = 400 WHERE Description = 'Trip from the database'");
                context.SaveChanges();
               // SaveWithConcurrencyResolution(context);
            }
        }
        /// <summary>
        /// 尝试保存
        /// </summary>
        private static void SaveWithConcurrencyResolution(DbContexts.DataAccess.BreakAwayContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ResolveConcurrencyConflicts(ex);
                SaveWithConcurrencyResolution(context);  //解决完冲突再保存
            }
        }

        /// <summary>
        /// 解决冲突
        /// </summary>
        private static void ResolveConcurrencyConflicts(DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                Console.WriteLine("Concurrency conflict found for {0}", entry.Entity.GetType());

                Console.WriteLine("\nYou are trying to save the following values:");
                PrintPropertyValues(entry.CurrentValues);  //用户修改的值

                Console.WriteLine("\nThe values before you started editing were:");
                PrintPropertyValues(entry.OriginalValues);  //从库里取出来时的值

                var databaseValues = entry.GetDatabaseValues();  //即时数据库的值
                Console.WriteLine("\nAnother user has saved the following values:");
                PrintPropertyValues(databaseValues);

                Console.WriteLine("[S]ave your values, [D]iscard you changes or [M]erge?");
                var action = Console.ReadKey().KeyChar.ToString().ToUpper(); //读取用户输入的字母
                switch (action)
                {
                    case "S":
                        entry.OriginalValues.SetValues(databaseValues);  //拷贝数据库值到当前值（恢复时间戳）
                        break;
                    case "D":
                        entry.Reload();  //重新加载
                        break;
                    case "M":
                        var mergedValues = MergeValues(entry.OriginalValues, entry.CurrentValues, databaseValues);//合并
                        entry.OriginalValues.SetValues(databaseValues);  //拷贝数据库值到当前值（恢复时间戳）
                        entry.CurrentValues.SetValues(mergedValues);     //拷贝合并后的值到当前值，最终保存的是当前值
                        break;
                    default:
                        throw new ArgumentException("Invalid option");
                }
            }
        }

        /// <summary>
        /// 合并
        /// </summary>
        private static DbPropertyValues MergeValues(DbPropertyValues original, DbPropertyValues current, DbPropertyValues database)
        {
            var result = original.Clone();  //拷贝原始值并存放合并后的值
            foreach (var propertyName in original.PropertyNames)  //遍历原始值的所有列
            {
                if (original[propertyName] is DbPropertyValues)  //判断当前列是否复杂类型（很少）
                {
                    var mergedComplexValues =
                        MergeValues((DbPropertyValues)original[propertyName],
                        (DbPropertyValues)current[propertyName],
                        (DbPropertyValues)database[propertyName]);  //是复杂类型的话就使用递归合并复杂类型的值
                    ((DbPropertyValues)result[propertyName]).SetValues(mergedComplexValues);
                }
                else  //是普通里的话就和当前值、数据库值、原始值各种对比。修改了就赋值
                {
                    if (!object.Equals(current[propertyName], original[propertyName]))
                        result[propertyName] = current[propertyName];
                    else if (!object.Equals(database[propertyName], original[propertyName]))
                        result[propertyName] = database[propertyName];
                }
            }
            return result;
        }

        /// <summary>
        /// 记录结果集的各种：增 / 删 /改
        /// </summary>
        private static void TestSaveLogging()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var canyon = (from d in context.Destinations
                              where d.Name == "Grand Canyon"
                              select d).Single();//加载主表数据

                context.Entry(canyon).Collection(d => d.Lodgings).Load();//显示加载出从表相关数据
                canyon.TravelWarnings = "Take a hat!";//修改主表字段
                context.Lodgings.Remove(canyon.Lodgings.First());//删除相关联从表的第一条数据
                context.Destinations.Add(new DbContexts.Model.Destination { Name = "Seattle, WA" });//添加一条主表数据
                context.LogChangesDuringSave = true; //设置标识，使用自定义的SaveChanges方法
                context.SaveChanges();
            }
        }
        #endregion

        #region 第五章
        /// <summary>
        /// 验证单个实体的属性：GetValidationResult().IsValid方法
        /// </summary>
        private static void ValidateNewPerson()
        {
            var person = new DbContexts.Model.Person
            {
                FirstName = "Julie",
                LastName = "Lermanaaaaaaaass",
                Photo = new DbContexts.Model.PersonPhoto { Photo = new Byte[] { 0 } }
            };
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                //if (context.Entry(person).GetValidationResult().IsValid)
                //    Console.WriteLine("Person is Valid");
                //else
                //    Console.WriteLine("Person is Invalid");

                var result = context.Entry(person).GetValidationResult();
                if (!result.IsValid)
                {
                    Console.WriteLine(result.ValidationErrors.First().ErrorMessage);
                }
            }
        }

        /// <summary>
        /// 通用的打印错误方法
        /// </summary>
        private static void ConsoleValidationResults(object entity)
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var result = context.Entry(entity).GetValidationResult();
                foreach (DbValidationError error in result.ValidationErrors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// 定制验证规则
        /// </summary>
        public static void ValidateDestination()
        {
            ConsoleValidationResults(new DbContexts.Model.Destination
              {
                  Name = "New York City",
                  Country = "U.S.A",
                  Description = "Big city! :) "
              });
        }

        /// <summary>
        /// 单独验证实体的属性
        /// </summary>
        private static void ValidatePropertyOnDemand()
        {
            var trip = new DbContexts.Model.Trip
                     {
                         EndDate = DateTime.Now,
                         StartDate = DateTime.Now,
                         CostUSD = 500.00M,
                         Description = "Hope you won't be freezing :)"
                     };
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var errors = context.Entry(trip).Property(t => t.Description).GetValidationErrors();
                Console.WriteLine("# Errors from Description validation: {0}", errors.Count());
            }
        }

        /// <summary>
        /// 验证实体单个属性：IValidatableObject接口的Validate方法
        /// </summary>
        private static void ValidateTrip()
        {
            ConsoleValidationResults(new DbContexts.Model.Trip
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(2),  //开始时间比结束时间晚2天
                CostUSD = 500.00M,
                Description = "Don't worry about freezing on this trip",  //待过滤的关键字
                //Description = "You should enjoy this 500 dollar trip",   //简介包含了价格
                Destination = new DbContexts.Model.Destination { Name = "Somewhere Fun" }
            });
        }

        /// <summary>
        /// 验证多个实体
        /// </summary>
        private static void ValidateEverything()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var station = new DbContexts.Model.Destination
                {
                    Name = "Antartica Research Station",
                    Country = "Antartica",
                    Description = "You will be freezing!"  //这个不通过验证：Description不能包括“！”
                };
                context.Destinations.Add(station);  //添加实体
                context.Trip.Add(new DbContexts.Model.Trip  //添加实体
                {
                    EndDate = new DateTime(2012, 4, 7),
                    StartDate = new DateTime(2012, 4, 1),
                    CostUSD = 500.00M,
                    Description = "A valid trip.",
                    Destination = station
                });
                context.Trip.Add(new DbContexts.Model.Trip  //添加实体
                {
                    EndDate = new DateTime(2012, 4, 7),
                    StartDate = new DateTime(2012, 4, 15),  //这个不通过验证：开始日期大于结束日期
                    CostUSD = 500.00M,
                    Description = "There were sad deaths last time.",
                    Destination = station
                });
                var dbTrip = context.Trip.First();
                dbTrip.Destination = station;
                dbTrip.Description = "don't worry, this one's from the database";  //修改实体（这个不通过验证：worry）

                DisplayErrors(context.GetValidationErrors());
                //使用SaveChanges代替GetValidationErrors方法验证实体
                //try
                //{
                //    context.SaveChanges();
                //    Console.WriteLine("Save Succeeded.");
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    Console.WriteLine("Validation failed for {0} objects", ex.EntityValidationErrors.Count());
                //}
            }
        }
        private static void DisplayErrors(IEnumerable<DbEntityValidationResult> results)
        {
            int counter = 0;
            foreach (DbEntityValidationResult result in results)
            {
                counter++;
                Console.WriteLine("Failed Object #{0}: Type is {1}", counter, result.Entry.Entity.GetType().Name);
                Console.WriteLine(" Number of Problems: {0}", result.ValidationErrors.Count);
                foreach (DbValidationError error in result.ValidationErrors)
                {
                    Console.WriteLine(" - {0}", error.ErrorMessage);
                }
            }
        }






        #endregion

        #region 第六章
        /// <summary>
        /// 先验证上下文，再验证自定义的规则
        /// </summary>
        private static void CreateDuplicateLodging()
        {
            using (var context = new DbContexts.DataAccess.BreakAwayContext())
            {
                var destination = context.Destinations.FirstOrDefault(d => d.Name == "Grand Canyon");
                try
                {
                    context.Lodgings.Add(new DbContexts.Model.Lodging
                    {
                        Destination = destination,
                        Name = "Grand Hotel"
                    });
                    context.SaveChanges();
                    Console.WriteLine("Save Successful");
                }
                catch (DbEntityValidationException ex)
                {                    
                    Console.WriteLine("Save Failed: ");
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, error.ValidationErrors.Select(v => v.ErrorMessage)));
                    }
                    return;
                }
            }
        }
        #endregion


    }
}
