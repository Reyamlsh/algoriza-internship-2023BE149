using Core;
using Core.Domain;
using Repository;
using System.Runtime.Intrinsics.X86;

namespace Repository1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();

            List<Specialization> specializations = new List<Specialization>()
            {
                  new Specialization()
                  {
                      name = "Dentistry"
                  },
                  new Specialization()
                  {
                      name = "Neurology"
                  },
                  new Specialization()
                  {
                      name = "Cardiology"
                  },
                  new Specialization()
                  {
                      name = "Dermatology"
                  },
                  new Specialization()
                  {
                      name = "Endocrinology"
                  },
                  new Specialization()
                  {
                      name = "Hematology"
                  },
                  new Specialization()
                  {
                      name = "Nephrology"
                  },
                  new Specialization()
                  {
                      name = "Dentistry"
                  },
                  new Specialization()
                  {
                      name = "Oncology"
                  },
                  new Specialization()
                  {
                      name = "Ophthalmology"
                  }
            };

            foreach (var specialization in specializations)
            {
                _context.Specializations.Add(specialization);
            }

////////////////////////////////////////////////////////////////////////////////////////////////
            List<Discount> discounts = new List<Discount>()
            {
                  new Discount()
                  {
                      code = "discount2023",
                      activationStatus = true,
                      type = DiscountType.Value,
                      value = 0.3
                  },
                  new Discount()
                  {
                      code = "discount2020",
                      activationStatus = false,
                      type = DiscountType.Percentage,
                      value = 0.2
                  },
                  new Discount()
                  {
                      code = "coupon2023",
                      activationStatus = true,
                      type = DiscountType.Percentage,
                      value = 0.5
                  }
            };

            foreach (var discount in discounts)
            {
                _context.Discounts.Add(discount);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////
            List<WorkingDateAndTime> workingTimes = new List<WorkingDateAndTime>()
            {
                  new WorkingDateAndTime()
                  {
                      day = Day.Saturday,
                      timeFrom = TimeSpan.FromHours(9),
                      timeTo = TimeSpan.FromHours(17),
                      price = 100
                  },
                  new WorkingDateAndTime()
                  {
                      day = Day.Sunday,
                      timeFrom = TimeSpan.FromHours(8),
                      timeTo = TimeSpan.FromHours(15),
                      price = 100
                  },
                  new WorkingDateAndTime()
                  {
                      day = Day.Monday,
                      timeFrom = TimeSpan.FromHours(12),
                      timeTo = TimeSpan.FromHours(20),
                      price = 100
                  },
                  new WorkingDateAndTime()
                  {
                      day = Day.Tuesday,
                      timeFrom = TimeSpan.FromHours(4),
                      timeTo = TimeSpan.FromHours(12),
                      price = 100
                  },
                  new WorkingDateAndTime()
                  {
                      day = Day.Wednesday,
                      timeFrom = TimeSpan.FromHours(9),
                      timeTo = TimeSpan.FromHours(14),
                      price = 100
                  },
                  new WorkingDateAndTime()
                  {
                      day = Day.Thursday,
                      timeFrom = TimeSpan.FromHours(14),
                      timeTo = TimeSpan.FromHours(22),
                      price = 100
                  },
                  new WorkingDateAndTime()
                  {
                      day = Day.Friday,
                      timeFrom = TimeSpan.FromHours(13),
                      timeTo = TimeSpan.FromHours(21),
                      price = 100
                  }
            };
         
            foreach (var workingTime in workingTimes)
            {
                _context.WorkingHours.Add(workingTime);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////
            List<Doctor> doctors = new List<Doctor>()
            {
                  new Doctor()//1
                  {
                    image = "Unknown_person.jpg",
                    firstName = "Reyam",
                    lastName = "Elshiny",
                    gender = Gender.Female,
                    DOB = "3/1/2001",
                    email = "reyam239@gmail.com",
                    phoneNumber = "010846529475",
                    password = "437hfdjh3",
                    workingHours = { workingTimes.ElementAt(1), workingTimes.ElementAt(5) },
                    workAddress = "Cairo",
                    specialization = specializations.ElementAt(1),
                    discounts = {}
                  },

                  new Doctor()//2
                  {
                    image = "",
                    firstName = "Roaa",
                    lastName = "Mohamed",
                    gender = Gender.Female,
                    DOB = "13/10/2003",
                    email = "roaa239@gmail.com",
                    phoneNumber = "010846529475",
                    password = "m45m7frte85",
                    workingHours = { workingTimes.ElementAt(1), workingTimes.ElementAt(5) },
                    workAddress = "Cairo",
                    specialization = specializations.ElementAt(1),
                    discounts = {}
                  },

                  new Doctor()//3
                  {
                    image = "Unknown_person.jpg",
                    firstName = "Ali",
                    lastName = "Ahmed",
                    gender = Gender.Male,
                    DOB = "25/8/1999",
                    email = "ali239@gmail.com",
                    phoneNumber = "014895354075",
                    password = "dfhbw45h37h",
                    workingHours = { workingTimes.ElementAt(3), workingTimes.ElementAt(5), workingTimes.ElementAt(5) },
                    workAddress = "Alexandria",
                    specialization = specializations.ElementAt(6),
                    discounts = {discounts.ElementAt(1)}
                  },

                  new Doctor()//4
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Mohammed",
                        lastName = "Hassan",
                        gender = Gender.Male,
                        DOB = "10/5/1985",
                        email = "mohammed239@gmail.com",
                        phoneNumber = "012345678901",
                        password = "mohammed_pass",
                        workingHours = { workingTimes.ElementAt(2), workingTimes.ElementAt(4), workingTimes.ElementAt(6) },
                        workAddress = "Giza",
                        specialization = specializations.ElementAt(2),
                        discounts = { discounts.ElementAt(1), discounts.ElementAt(2) }
                    },
                  new Doctor()//5
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Sarah",
                        lastName = "Smith",
                        gender = Gender.Female,
                        DOB = "15/9/1990",
                        email = "sarah239@gmail.com",
                        phoneNumber = "012345678905",
                        password = "sarah_pass",
                        workingHours = { workingTimes.ElementAt(0), workingTimes.ElementAt(1), workingTimes.ElementAt(3) },
                        workAddress = "New York",
                        specialization = specializations.ElementAt(9),
                        discounts = {  }
                    },
                  new Doctor()//6
                    {
                        image = "Unknown_person.jpg",
                        firstName = "John",
                        lastName = "Doe",
                        gender = Gender.Male,
                        DOB = "20/3/1980",
                        email = "john239@gmail.com",
                        phoneNumber = "012345678910",
                        password = "john_pass",
                        workingHours = { workingTimes.ElementAt(2), workingTimes.ElementAt(4), workingTimes.ElementAt(6) },
                        workAddress = "Los Angeles",
                        specialization = specializations.ElementAt(3),
                        discounts = { discounts.ElementAt(1), discounts.ElementAt(1) }
                    },

                    new Doctor()//7
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Aisha",
                        lastName = "Abdullah",
                        gender = Gender.Female,
                        DOB = "5/7/1995",
                        email = "aisha239@gmail.com",
                        phoneNumber = "012345678911",
                        password = "aisha_pass",
                        workingHours = { workingTimes.ElementAt(3), workingTimes.ElementAt(5), workingTimes.ElementAt(5) },
                        workAddress = "Dubai",
                        specialization = specializations.ElementAt(4),
                        discounts = { discounts.ElementAt(1), discounts.ElementAt(2) }
                    },

                    new Doctor()//8
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Michael",
                        lastName = "Johnson",
                        gender = Gender.Male,
                        DOB = "12/6/1988",
                        email = "michael239@gmail.com",
                        phoneNumber = "012345678915",
                        password = "michael_pass",
                        workingHours = { workingTimes.ElementAt(1), workingTimes.ElementAt(1), workingTimes.ElementAt(3) },
                        workAddress = "Toronto",
                        specialization = specializations.ElementAt(1),
                        discounts = { discounts.ElementAt(1), discounts.ElementAt(2) }
                    },

                    new Doctor()//9
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Emily",
                        lastName = "Williams",
                        gender = Gender.Female,
                        DOB = "8/11/1983",
                        email = "emily239@gmail.com",
                        phoneNumber = "012345678916",
                        password = "emily_pass",
                        workingHours = { workingTimes.ElementAt(2), workingTimes.ElementAt(4), workingTimes.ElementAt(6) },
                        workAddress = "Sydney",
                        specialization = specializations.ElementAt(1),
                        discounts = {  }
                    },

                    new Doctor()//10
                    {
                        image = "Unknown_person.jpg",
                        firstName = "David",
                        lastName = "Taylor",
                        gender = Gender.Male,
                        DOB = "14/9/1992",
                        email = "david239@gmail.com",
                        phoneNumber = "012345678917",
                        password = "david_pass",
                        workingHours = { workingTimes.ElementAt(3), workingTimes.ElementAt(5), workingTimes.ElementAt(5) },
                        workAddress = "London",
                        specialization = specializations.ElementAt(5),
                        discounts = { discounts.ElementAt(1) }
                    },

                    new Doctor()//11
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Sophia",
                        lastName = "Clark",
                        gender = Gender.Female,
                        DOB = "3/6/1987",
                        email = "sophia239@gmail.com",
                        phoneNumber = "012345678920",
                        password = "sophia_pass",
                        workingHours = { workingTimes.ElementAt(1), workingTimes.ElementAt(1), workingTimes.ElementAt(3) },
                        workAddress = "Paris",
                        specialization = specializations.ElementAt(2),
                        discounts = {}
                    },

                    new Doctor()//12
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Elena",
                        lastName = "Gonzalez",
                        gender = Gender.Female,
                        DOB = "22/4/1986",
                        email = "elena239@gmail.com",
                        phoneNumber = "012345678921",
                        password = "elena_pass",
                        workingHours = { workingTimes.ElementAt(2), workingTimes.ElementAt(4), workingTimes.ElementAt(5) },
                        workAddress = "Barcelona",
                        specialization = specializations.ElementAt(3),
                        discounts = { discounts.ElementAt(1), discounts.ElementAt(2) }
                    },

                    new Doctor()//13
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Sebastian",
                        lastName = "Lopez",
                        gender = Gender.Male,
                        DOB = "17/12/1989",
                        email = "sebastian239@gmail.com",
                        phoneNumber = "012345678922",
                        password = "sebastian_pass",
                        workingHours = { workingTimes.ElementAt(3), workingTimes.ElementAt(5), workingTimes.ElementAt(5) },
                        workAddress = "Madrid",
                        specialization = specializations.ElementAt(4),
                        discounts = { discounts.ElementAt(1) }
                    },

                    new Doctor()//14
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Emma",
                        lastName = "Jones",
                        gender = Gender.Female,
                        DOB = "11/8/1984",
                        email = "emma239@gmail.com",
                        phoneNumber = "012345678924",
                        password = "emma_pass",
                        workingHours = { workingTimes.ElementAt(0), workingTimes.ElementAt(1), workingTimes.ElementAt(3) },
                        workAddress = "Berlin",
                        specialization = specializations.ElementAt(2),
                        discounts = { discounts.ElementAt(0), discounts.ElementAt(2) }
                    },

                    new Doctor()//15
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Omar",
                        lastName = "Al-Farsi",
                        gender = Gender.Male,
                        DOB = "5/9/1982",
                        email = "omar239@gmail.com",
                        phoneNumber = "012345678925",
                        password = "omar_pass",
                        workingHours = { workingTimes.ElementAt(2), workingTimes.ElementAt(4), workingTimes.ElementAt(5) },
                        workAddress = "Riyadh",
                        specialization = specializations.ElementAt(6),
                        discounts = { }
                    }
            };

            foreach (var doctor in doctors)
            {
                _context.Doctors.Add(doctor);
            }

/////////////////////////////////////////////////////////////////////////////////////////
            List<Patient> patients = new List<Patient>()
            {
                  new Patient()
                  {
                      image = "",
                        firstName = "Reyam",
                        lastName = "Elshiny",
                        gender = Gender.Female,
                        DOB = "3/1/2001",
                        email = "rere312001@gmial.com",
                        phoneNumber = "01553503722",
                        password = "437hfdjh3"
                  },
                  new Patient()//2
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Ahmed",
                        lastName = "Ali",
                        gender = Gender.Male,
                        DOB = "15/7/1995",
                        email = "ahmed239@gmail.com",
                        phoneNumber = "01553503723",
                        password = "ahmed_pass"
                    },

                    new Patient()//3
                    {
                        image = "",
                        firstName = "Lina",
                        lastName = "Khalid",
                        gender = Gender.Female,
                        DOB = "20/12/1988",
                        email = "lina239@gmail.com",
                        phoneNumber = "01553503724",
                        password = "lina_pass"
                    },


                    new Patient()//4
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Alex",
                        lastName = "Smith",
                        gender = Gender.Male,
                        DOB = "10/3/1982",
                        email = "alex239@gmail.com",
                        phoneNumber = "01553503731",
                        password = "alex_pass"
                    },
                    new Patient()//5
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Sara",
                        lastName = "Ahmed",
                        gender = Gender.Female,
                        DOB = "8/6/1990",
                        email = "sara239@gmail.com",
                        phoneNumber = "01553503732",
                        password = "sara_pass"
                    },

                    new Patient()//6
                    {
                        image = "",
                        firstName = "Mohammed",
                        lastName = "Omar",
                        gender = Gender.Male,
                        DOB = "25/9/1987",
                        email = "mohammed239@gmail.com",
                        phoneNumber = "01553503733",
                        password = "mohammed_pass"
                    },

                    new Patient()//7
                    {
                        image = "Unknown_person.jpg",
                        firstName = "Hana",
                        lastName = "Khaled",
                        gender = Gender.Female,
                        DOB = "12/4/1993",
                        email = "hana239@gmail.com",
                        phoneNumber = "01553503734",
                        password = "hana_pass"
                    },

                    new Patient()//8
                        {
                            image = "Unknown_person.jpg",
                            firstName = "Mona",
                            lastName = "Hassan",
                            gender = Gender.Female,
                            DOB = "14/2/1985",
                            email = "mona239@gmail.com",
                            phoneNumber = "01553503735",
                            password = "mona_pass"
                        },

                        new Patient()//9
                        {
                            image = "",
                            firstName = "Karim",
                            lastName = "Mahmoud",
                            gender = Gender.Male,
                            DOB = "5/11/1998",
                            email = "karim239@gmail.com",
                            phoneNumber = "01553503736",
                            password = "karim_pass"
                        },

                        new Patient()//10
                        {
                            image = "Unknown_person.jpg",
                            firstName = "Dina",
                            lastName = "Ezzat",
                            gender = Gender.Female,
                            DOB = "3/9/1991",
                            email = "dina239@gmail.com",
                            phoneNumber = "01553503737",
                            password = "dina_pass"
                        }

            };

            foreach (var patient in patients)
            {
                _context.Patients.Add(patient);
            }

            Admin admin1 = new Admin()
            {
                image = "",
                firstName = "Moha",
                lastName = "salah",
                gender = Gender.Male,
                DOB = "4/5/1990",
                email = "moha@gmial.com",
                phoneNumber = "548535654",
                password = "f54f873995"
            };

            _context.Admins.Add(admin1);

            List<Appointment> appoints = new List<Appointment>()
            {
                  new Appointment()
                  {
                      patient = patients.ElementAt(1),
                        doctor = doctors.ElementAt(2),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(2),
                        doctor = doctors.ElementAt(10),
                        appointmentTime = workingTimes.ElementAt(6),
                        status = AppointmentStatus.Pending,
                        discount = null,
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(3),
                        doctor = doctors.ElementAt(2),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(4),
                        doctor = doctors.ElementAt(2),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(5),
                        doctor = doctors.ElementAt(10),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(6),
                        doctor = doctors.ElementAt(4),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(7),
                        doctor = doctors.ElementAt(2),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(8),
                        doctor = doctors.ElementAt(3),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(9),
                        doctor = doctors.ElementAt(3),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  },
                  new Appointment()
                  {
                      patient = patients.ElementAt(10),
                        doctor = doctors.ElementAt(3),
                        appointmentTime = workingTimes.ElementAt(1),
                        status = AppointmentStatus.Pending,
                        discount = discounts.ElementAt(1),
                  }

            };


            _context.SaveChanges();

            Console.WriteLine("Done!");
        }
    }
}
