using System.ServiceProcess;

namespace ApiAdapter
{
    public partial class ApiAdapter : ServiceBase
    {
        public ApiAdapter()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
        }

        protected override void OnStop()
        {
        }
    }
}
