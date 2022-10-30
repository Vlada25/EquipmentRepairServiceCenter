namespace EquipmentRepairServiceCenter.ASP.LocalDto
{
    public class OrderUpdatedForView
    {
        public Guid Id { get; set; }

        public string RepairingModelName { get; set; }
        public string RepairingModelSpecifications { get; set; }
        public string RepairingModelParticularQualities { get; set; }


        public string FaultName { get; set; }
        public string RepairingMethods { get; set; }

        public int RepairingTimeInDays { get; set; }
        public decimal Price { get; set; }

        public int GuaranteeInMonth { get; set; }
    }
}
