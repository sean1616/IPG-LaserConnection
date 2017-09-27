using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthernetConnection.ViewModel;
using EthernetConnection.SPI_Command;
using EthernetConnection.Pages;

namespace EthernetConnection.GlobalChannel
{
    public class ET_GlobalChannel
    {
        public static Et_vm Et_vm { get; set; } = new Et_vm();
        public static Command_cal command_cal { get; set; } = new Command_cal();
        //public static SPI_Page SPI_page { get; set; } = new SPI_Page();
    }
}
