using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MenuItems.Features
{
    public class MenuItem : IVisible, IEnumerable<SubmenuItem>
    {
        public int Id { get; private set; }
        public List<SubmenuItem> SubmenuItems { get; private set; }

        private static int nextId = 1;

        public MenuItem()
        {
            Id = nextId++;
            SubmenuItems = new List<SubmenuItem>();
        }

        public bool IsVisible()
        {
            if (SubmenuItems == null)
            {
                return false;
            }
            if (!SubmenuItems.Any())
            {
                return false;
            }
            if (!SubmenuItems.Any(q => q.IsVisible()))
            {
                return false;
            }
            return true;
        }

        public bool CanShowDivider(List<MenuItem> menuItems)
        {
            return Id != menuItems.Where(m => m.IsVisible()).Last().Id;
        }

        public void Add(SubmenuItem item)
        {
            SubmenuItems.Add(item);
        }

        public IEnumerator<SubmenuItem> GetEnumerator()
        {
            return SubmenuItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SubmenuItems.GetEnumerator();
        }
    }
}