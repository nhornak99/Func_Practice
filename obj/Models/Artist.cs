namespace FP_Practice.Models {
    public class Artist { 
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } = "";

        internal string FullName{
            get{
                if(string.IsNullOrEmpty(LastName)){
                    return FirstName;
                }
                return FirstName + ' ' + LastName;
            }
        }


    }
}