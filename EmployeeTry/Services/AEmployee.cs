namespace EmployeeTry.Services
{
    public abstract class AEmployee
    {
        public decimal? CalculateSalary( decimal? salary, string type)
        {
            decimal? basic;
            switch (type.ToLower())
            {
                case "permanent":
                    basic = salary + (salary * (decimal)0.30);
                    break;
                case "temporory":
                    basic = salary + (salary * (decimal)0.10);
                    break;

                default: basic = salary; break;
            }
           return basic;
        }
    }
}
