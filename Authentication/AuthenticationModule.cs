using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Nancy;

namespace cmas.backend.Authentication
{
    public class AuthenticationModule : NancyModule
    {
        private List<UserRole> AvailableRoles;
        private List<UserModel> Users;


        public AuthenticationModule()
        {
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));


            MockAvailableRoles();
            MockUsers();

            Post("/api/authentication/login", args =>
            {
                var login = this.Request.Form["login"].Value;
                var password = this.Request.Form["password"].Value;

                var user = (from u in Users where u.Login == login && u.Password == password select u).SingleOrDefault();

                if (user != null)
                    return Response.AsJson(user);

                return HttpStatusCode.Forbidden;
            });
        }


        private void MockAvailableRoles()
        {
            AvailableRoles = new List<UserRole>();

            int idCounter = 0;


            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    1
                Description = "Старший менеджер"
            });


            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    2
                Description = "Менеджер"
            });


            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    3
                Description = "Руководитель"
            });

            AvailableRoles.Add(new UserRole
            {
                Id = ++idCounter, //    4
                Description = "Подрядчик"
            });
        }

        private void MockUsers()
        {
            Users = new List<UserModel>();
            int idCounter = 0;


            // Старший менеджер
            {
                var seniorManager = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "Senior",
                    LastName = "Manager",
                    Login = "SeniorManager",
                    Password = "111"
                };

                seniorManager.UserRole.Add((from r in AvailableRoles where r.Id == 1 select r)
                    .Single());

                Users.Add(seniorManager);
            }


            // Менеджер
            {
                var generalManager = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "",
                    LastName = "Manager",
                    Login = "GeneralManager",
                    Password = "111"
                };

                generalManager.UserRole.Add((from r in AvailableRoles where r.Id == 2 select r)
                    .Single());

                Users.Add(generalManager);
            }


            // Руководитель
            {
                var сhief = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "",
                    LastName = "Сhief",
                    Login = "Сhief",
                    Password = "111"
                };

                сhief.UserRole.Add((from r in AvailableRoles where r.Id == 3 select r)
                    .Single());

                Users.Add(сhief);
            }

            // Подрядчик
            {
                var contractor = new UserModel
                {
                    Id = ++idCounter,
                    FirstName = "",
                    LastName = "Contractor",
                    Login = "Contractor",
                    Password = "111"
                };

                contractor.UserRole.Add((from r in AvailableRoles where r.Id == 4 select r)
                    .Single());

                Users.Add(contractor);
            }
        }
    }
}


