using System.Collections.Generic;

namespace WebMvc.ViewModels.HomeViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}
