using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class ViewVigilanceAwarenessViewModel
    {
        public List<Tran_a_1b_capacitybulidingprogram_ViewModel> CapacityBuiliding_VM {  get; set; }
        public List<Tran_a_2b_sysimp_ViewModel> Sys_Improvement_VM { get; set; }
        public List<Tran_a_3b_updation_circular_guidelines_manuals_ViewModel> UpdationCirculars_VM {  get; set; }
        public List<Tran_a_4b_disposalofcomplaints_ViewModel> DisposalComplaints_VM { get; set; }
        public List<Tran_a_5b_dynamicdigitalpresence_ViewModel> DynamicDigitalPresence_VM { get; set; }
        public ViewVigilanceAwarenessViewModel()
        {
            CapacityBuiliding_VM = new List<Tran_a_1b_capacitybulidingprogram_ViewModel>();
            Sys_Improvement_VM = new List<Tran_a_2b_sysimp_ViewModel>();
            UpdationCirculars_VM = new List<Tran_a_3b_updation_circular_guidelines_manuals_ViewModel>();
            DisposalComplaints_VM = new List<Tran_a_4b_disposalofcomplaints_ViewModel>();
            DynamicDigitalPresence_VM = new List<Tran_a_5b_dynamicdigitalpresence_ViewModel>();
        }
    }
}