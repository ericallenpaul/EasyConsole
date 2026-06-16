namespace EasyConsole
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public Program Program { get; set; }

        public Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            if (Program.History.Count > 1 && Program.BreadcrumbHeader)
            {
                var breadcrumb = string.Join(" > ", Program.History.Select(page => page.Title).Reverse());
                Console.WriteLine(breadcrumb);
            }
            else
            {
                Console.WriteLine(Title);
            }
            Console.WriteLine("---");
        }
    }
}
