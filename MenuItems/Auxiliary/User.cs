using System;

namespace MenuItems.Auxiliary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public Gender Gender { get; set; }
        public bool Manager { get; set; }
        public bool Coordinator { get; set; }
        public bool Active { get; set; }

        public bool CanIncludeUser()
        {
            CheckUser();
            return Manager;
        }

        public bool CanChangeUserData()
        {
            CheckUser();
            return Manager || Coordinator;
        }

        public bool CanDeleteUser()
        {
            CheckUser();
            return Manager;
        }

        public bool CanDelegateTasks()
        {
            CheckUser();
            return Coordinator;
        }

        public bool CanChangeTheirOwnData()
        {
            CheckUser();
            return Active;
        }

        private void CheckUser()
        {
            if (Id == default(int))
            {
                throw new ArgumentException("It's necessary inform the Id.");
            }
            else if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("It's necessary inform the Name.");
            }
            else if (BirthdayDate == null)
            {
                throw new ArgumentException("It's necessary inform the Birthday Date.");
            }
        }
    }

    public enum Gender
    {
        Female,
        Male
    }
}