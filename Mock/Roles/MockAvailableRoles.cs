using System.Collections.Generic;
using cmas.backend.Authentication;

namespace cmas.backend.Mock.Roles
{
    public class MockAvailableRoles
    {


        public static List<UserRole> Generate()
        {
            var AvailableRoles = new List<UserRole>();

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

            return AvailableRoles;
        }
    }
}