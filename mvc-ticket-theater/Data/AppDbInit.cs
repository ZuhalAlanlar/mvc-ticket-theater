using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using mvc_ticket_theater.Data.Static;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data
{
    public class AppDbInit
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Saloons
                if (!context.Saloons.Any())
                {
                    context.Saloons.AddRange(new List<Saloon>()
                    {
                        new Saloon()
                        {
                            Name = "Harbiye Muhsin Ertuğrul Salonu",
                            SaloonImg = "https://stcdn.ibb.istanbul/Uploads/2017/8/muhsinertugrulsahnesi2.jpg?height=410&width=604&quality=80",
                            Adress = "Harbiye"
                        },
                        new Saloon()
                        {
                            Name = "Reşat Nuri Salonu",
                            SaloonImg = "https://stcdn.ibb.istanbul/Uploads/2017/12/Fatih-Resat-Nuri-Sahnesi-Slide3.jpg?height=410&width=604&quality=80",
                            Adress = "Unkapanı,Fatih"
                        },
                        new Saloon()
                        {
                          Name = "Kadıköy Haldun Taner Salonu",
                            SaloonImg = "https://stcdn.ibb.istanbul/Uploads/2017/8/kadikoy2.jpg?height=410&width=604&quality=80",
                            Adress = "Kadıköy"
                        },
                        new Saloon()
                        {
                         Name = "Beylikdüzü Atatürk Kültür ve Sanat Merkezi",
                            SaloonImg = "https://stcdn.ibb.istanbul/Uploads/2020/3/Beylikduzu6.jpeg?height=410&width=604&quality=80",
                            Adress = "Beylikdüzü,İstanbul"
                        },
                        new Saloon()
                        {
                            Name = "Nazım Hikmet Kültür ve Sanat Evi",
                            SaloonImg = "https://stcdn.ibb.istanbul/Uploads/2021/10/nazim-hikmet-kultur-merkezi.jpeg?height=410&width=604&quality=80",
                            Adress = "Şişli,İstanbul"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Elif Verit",
                            Bio = "ATATÜRK ÜNİVERSİTESİ, Güzel Sanatlar Fakültesi, Sahne Sanatları Bölümü",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/elif-verit1.jpg?width=235&height=327"

                        },
                        new Actor()
                        {
                            FullName = "Hakan Örge",
                            Bio = "Sahne, Oyunculuk, Doğaçlama, Modern Dans Eğitimi, Kukla ve Karagöz eğitimi – BAŞKENT TİYATROSU",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/Hakan-orge1.jpg?width=235&height=327"
                        },
                        new Actor()
                        {
                            FullName = "İrem Erkaya",
                            Bio = "1978 İstanbul doğumlu. 2001 yılında Akademi İstanbul Tiyatro bölümünden mezun oldu",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/irem-Erkaya1.jpg?width=235&height=327"
                        },
                        new Actor()
                        {
                            FullName = "Bennu Yıldırımlar",
                            Bio = " Londra – Westminster Education İnstitute – Drama Kursları, İstanbul Üniversitesi Devlet Konservatuarı – Tiyatro Bölümü",
                            ProfilePictureURL = "https://sehirtiyatrolari.ibb.istanbul/Artist/Detail/175"
                        },
                        new Actor()
                        {
                            FullName = "Doğan Şirin",
                            Bio = "2003 - 2008 Rolling dance art modern dans, 2003 - 2005 Biz oyuncular sahnesi oyunculuk,",
                            ProfilePictureURL = "https://sehirtiyatrolari.ibb.istanbul/Artist/Detail/232"
                        }
                    });
                    context.SaveChanges();
                }
                //Yönetmeenler
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Ayşegül İşsever",
                            Bio = "20 Eylül 1962 tarihinde Ankara'da doğdu",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/aysegul-issever1.jpg?width=235&height=327"

                        },
                        new Producer()
                        {
                            FullName = "Can Başak",
                            Bio = "Öğrenimi: İstanbul Üniversitesi Devlet Konservatuvarı Tiyatro Bölümü",
                            ProfilePictureURL = "https://sehirtiyatrolari.ibb.istanbul/Artist/Detail/194"
                        },
                        new Producer()
                        {
                            FullName = "Çağrı Hün",
                            Bio = "İstanbul Üniversitesi Devlet Konservatuvarı",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/cagri-Hun-(2)1.jpg?width=235&height=327"
                        },
                        new Producer()
                        {
                            FullName = "Caner Bilginer",
                            Bio = "T.C Kadir Has Üniversitesi Film ve Drama yüksek lisans.",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/Caner-Bilginer1.jpg?width=235&height=327"
                        },
                        new Producer()
                        {
                            FullName = "Cem Karakaya",
                            Bio = "Eğitim Durumu: İstanbul Üniversitesi Edebiyat Fakültesi Tiyatro Bölümü",
                            ProfilePictureURL = "https://stcdn.ibb.istanbul/Uploads/2020/3/cem-karakaya1.jpg?width=235&height=327"
                        }
                    });
                    context.SaveChanges();
                }
                //Tiyatrolar
                if (!context.Theaters.Any())
                {
                    context.Theaters.AddRange(new List<Theater>()
                    {
                        new Theater()
                        {
                            Name = "12.Gece",
                            Description = "Shakespeare'in en sevilen komedilerinden biri",
                            Price = 39.50,
                            TheaterImg = "https://stcdn.ibb.istanbul/Uploads/2019/12/on-ikinci-gece-son-afis.jpg?width=600&height=847",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SaloonId = 3,
                            ProducerId = 3,
                            Category = Enums.Category.Dram
                        },
                        new Theater()
                        {
                            Name = "Birgün Ayakkabımın Tek",
                            Description = "Rengarenk bir mutfak... Ama her yer çok dağınık..",
                            Price = 29.50,
                            TheaterImg = "https://stcdn.ibb.istanbul/Uploads/2017/10/Bir-Gun-Ayakkabimin-Teki-Afis.jpg?width=600&height=847",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            SaloonId = 1,
                            ProducerId = 1,
                             Category = Enums.Category.Komedi
                        },
                        new Theater()
                        {
                            Name = "GÜL'E Ağıt",
                            Description = "Türkiye'de işlenen töre cinayetlerinin simgesi haline gelen Güldünya’nın hikâyesi ekseninde namus, töre ve ahlak kavramlarını sorguluyor.",
                            Price = 39.50,
                            TheaterImg = "https://stcdn.ibb.istanbul/Uploads/2022/2/gule-agit-afis-02.jpg?width=390&height=550",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            SaloonId = 4,
                            ProducerId = 4,
                            Category = Enums.Category.Dram
                        },
                        new Theater()
                        {
                            Name = "Karagöz Çiftlik Bekçisi",
                            Description = "Karagöz Çocuk Oyunu",
                            Price = 39.50,
                            TheaterImg = "https://stcdn.ibb.istanbul/Uploads/2017/9/Karagoz-ciftlik-Bekcisi-Afis.jpg?width=600&height=847",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            SaloonId = 1,
                            ProducerId = 2,
                            Category = Enums.Category.Çocuk
                        },

                    });
                    context.SaveChanges();
                }
                //Tiyatro_aktör
                if (!context.Theaters_Actors.Any())
                {
                    context.Theaters_Actors.AddRange(new List<Theater_Actor>()
                    {
                        new Theater_Actor()
                        {
                            ActorId = 1,
                            TheaterId = 1
                        },
                        new Theater_Actor()
                        {
                            ActorId = 3,
                            TheaterId = 1
                        },

                         new Theater_Actor()
                        {
                            ActorId = 1,
                            TheaterId = 2
                        },
                         new Theater_Actor()
                        {
                            ActorId = 4,
                            TheaterId = 2
                        },

                        new Theater_Actor()
                        {
                            ActorId = 1,
                            TheaterId = 3
                        },
                        new Theater_Actor()
                        {
                            ActorId = 2,
                            TheaterId = 3
                        },
                        new Theater_Actor()
                        {
                            ActorId = 5,
                            TheaterId = 3
                        },


                        new Theater_Actor()
                        {
                            ActorId = 2,
                            TheaterId = 4
                        },
                        new Theater_Actor()
                        {
                            ActorId = 3,
                            TheaterId = 4
                        },
                        new Theater_Actor()
                        {
                            ActorId = 4,
                            TheaterId = 4
                        },






                    });
                    context.SaveChanges();
                }
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
               

          
                string adminUserEmail1 = "ercan@ozturk.com";

                var adminUser2 = await userManager.FindByEmailAsync(adminUserEmail1);
                if (adminUser2 == null)
                {
                    var newAdminUser1 = new AppUser()
                    {
                        FullName = "Admin User2",
                        UserName = "admin-user2",
                        Email = adminUserEmail1,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser1, "BlgAdam123?@");
                    await userManager.AddToRoleAsync(newAdminUser1, UserRoles.Admin);
                }


            }





        }

    }
}
