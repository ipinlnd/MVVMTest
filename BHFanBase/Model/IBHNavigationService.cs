using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHFanBase.Model
{
    public interface IBHNavigationService : INavigationService
    {
        object Parameter { get; set; }
    }
}
