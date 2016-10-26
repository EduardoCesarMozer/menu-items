using MenuItems.Auxiliary;
using MenuItems.Features;
using System;
using System.Collections.Generic;

namespace MenuItems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user = GetUser();
            var menuItems = GetMenuItems();

            foreach (MenuItem menuItem in menuItems)
            {
                if (menuItem.IsVisible())
                {
                    foreach (SubmenuItem submenuItem in menuItem.SubmenuItems)
                    {
                        if (submenuItem.IsVisible())
                        {
                            if (submenuItem.Show(user.CanChangeTheirOwnData))
                            {
                                Console.WriteLine("- Edit data");
                            }
                            else if (submenuItem.Show(user.CanChangeUserData))
                            {
                                Console.WriteLine("- Edit another user data");
                            }
                            else if (submenuItem.Show(user.CanDelegateTasks))
                            {
                                Console.WriteLine("- Delegate tasks");
                            }
                            else if (submenuItem.Show(user.CanDeleteUser))
                            {
                                Console.WriteLine("- Delete user");
                            }
                            else if (submenuItem.Show(user.CanIncludeUser))
                            {
                                Console.WriteLine("- Include new user");
                            }
                        }
                    }
                    if (menuItem.CanShowDivider(menuItems))
                    {
                        Console.WriteLine("############ Divider ############");
                    }
                }
            }
        }

        #region Helper methods

        private static User GetUser()
        {
            return new User()
            {
                Id = 1,
                Name = "Eddie",
                BirthdayDate = DateTime.Now,
                Gender = Gender.Male,
                Manager = true,
                Coordinator = false,
                Active = true
            };
        }

        private static List<MenuItem> GetMenuItems()
        {
            var user = GetUser();

            return new List<MenuItem>
            {
                new MenuItem()
                {
                    new SubmenuItem(user.CanChangeTheirOwnData)
                },
                new MenuItem()
                {
                    new SubmenuItem(user.CanIncludeUser),
                    new SubmenuItem(user.CanChangeUserData),
                    new SubmenuItem(user.CanDeleteUser),
                    new SubmenuItem(user.CanDelegateTasks)
                }
            };
        }

        #endregion
    }
}