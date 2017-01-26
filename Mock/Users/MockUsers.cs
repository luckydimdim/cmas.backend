using System.Collections.Generic;
using cmas.backend.Authentication;
using System.Linq;

namespace cmas.backend.Mock.Users
{
    public class MockUsers
    {
        public static List<UserModel>  Generate(List<UserRole> AvailableRoles)
        {
            var Users = new List<UserModel>();
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

            return Users;
        }
    }
}