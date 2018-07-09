using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymTracker.Data;
using GymTracker.Models;
using GymTracker.ViewModel;

namespace GymTracker.Controllers
{
    public class MembersController : Controller
    {
        private readonly GymContext _context;

        public MembersController(GymContext context)
        {
            _context = context;
        }

        

        // GET: Members
        public async Task<IActionResult> Index(string sortOrder)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            List<MemberViewModel> memberViewModel = new List<MemberViewModel>(); //declared my VIewModel instance

            var listData = await (from member in _context.Members
                                  join membershiptypes in _context.MembershipTypes on member.MembershipTypeId equals membershiptypes.MembershipTypeId
                                  select new
                                  {
                                      member.Id,
                                      member.FirstName,
                                      member.LastName,
                                      member.DateOfBirth,
                                      member.TelephoneNumber,
                                      membershiptypes.PaymentType
                                  }
                                  ).ToListAsync();

          

            listData.ForEach(x =>
            {
                MemberViewModel Obj = new MemberViewModel();
                Obj.MemberID = x.Id;
                Obj.FirstName = x.FirstName;
                Obj.LastName = x.LastName;
                Obj.DateOfBirth = x.DateOfBirth;
                Obj.TelephoneNumber = x.TelephoneNumber;
                Obj.PaymentType = x.PaymentType;
                memberViewModel.Add(Obj);


            }


            );

            switch (sortOrder)
            {
                case "firstname_desc":
                    memberViewModel = memberViewModel.OrderByDescending(m => m.FirstName).ToList();
                    break;

                case "Date":
                    memberViewModel = memberViewModel.OrderBy(m => m.DateOfBirth).ToList();
                    break;

                case "date_desc":
                    memberViewModel = memberViewModel.OrderByDescending(m => m.DateOfBirth).ToList();
                    break;
                   

                default:
                    memberViewModel = memberViewModel.OrderBy(m => m.FirstName).ToList();
                    break;

            }


            return View(memberViewModel.ToList());
           // return View(await _context.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<MemberViewModel> memberViewModel = new List<MemberViewModel>(); //declared my VIewModel instance

            var listData = await (from member in _context.Members
                                  where (member.Id == id)
                                  join membershiptypes in _context.MembershipTypes on member.MembershipTypeId equals membershiptypes.MembershipTypeId
                             
                                  select new
                                  {
                                      member.Id,
                                      member.FirstName,
                                      member.LastName,
                                      member.DateOfBirth,
                                      member.TelephoneNumber,
                                      membershiptypes.PaymentType
                      
                                      
                                  }
                                  ).ToListAsync();

            listData.ForEach(x =>
            {
                MemberViewModel Obj = new MemberViewModel();
                Obj.MemberID = x.Id;
                Obj.FirstName = x.FirstName;
                Obj.LastName = x.LastName;
                Obj.DateOfBirth = x.DateOfBirth;
                Obj.TelephoneNumber = x.TelephoneNumber;
                Obj.PaymentType = x.PaymentType;
              
                memberViewModel.Add(Obj);


            }


            );

            //link the viewModel instance to the context class somehow..


            return View(memberViewModel);
        }


        public async Task<IActionResult> ShowPayMonthly()
        {


            List<MemberViewModel> memberViewModel = new List<MemberViewModel>(); //declared my VIewModel instance

            var listData = await (from member in _context.Members
                                  where member.MembershipTypeId == 1   //get only the Pay Monthly Members
                                  join membershiptypes in _context.MembershipTypes on member.MembershipTypeId equals membershiptypes.MembershipTypeId
                                  select new
                                  {
                                      member.Id,
                                      member.FirstName,
                                      member.LastName,
                                      member.DateOfBirth,
                                      member.TelephoneNumber,
                                      membershiptypes.PaymentType
                                  }
                                  ).ToListAsync();

            listData.ForEach(x =>
            {
                MemberViewModel Obj = new MemberViewModel();
                Obj.MemberID = x.Id;
                Obj.FirstName = x.FirstName;
                Obj.LastName = x.LastName;
                Obj.DateOfBirth = x.DateOfBirth;
                Obj.TelephoneNumber = x.TelephoneNumber;
                Obj.PaymentType = x.PaymentType;
                memberViewModel.Add(Obj);


            }


            );

            //link the viewModel instance to the context class somehow..


            return View(memberViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> BookClass(int id)
        {
          
            List<MemberClassViewModel> memberClassViewModel = new List<MemberClassViewModel>();
            var classlist = _context.Classes.OrderBy(c=>c.ClassName).Select(x => new { Id = x.Id, Value = x.ClassName });
            var listData = await (_context.Classes.Select(x =>
                                  new
                                  {
                                      x.Id,
                                      x.ClassName,
                                     
                                  }
            ).ToListAsync());




            //var listData = await
            //(from Classes in _context.Classes join classesbooked in _context.ClassesBooked on Classes.Id equals classesbooked.ClassID
            // select new
            // {
            //     Classes.Id,
            //     Classes.ClassName,
            //     classesbooked.MemberID
            // }
            //                      ).ToListAsync();



            listData.ForEach
            (x =>
            {
                MemberClassViewModel Obj = new MemberClassViewModel();
               
                Obj.ClassID = x.Id;
                Obj.MemberID = id;

                Obj.ClassName = x.ClassName;
                //Obj.ClassName = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(classlist, "Id", "Value");
                memberClassViewModel.Add(Obj);

            }
            );
           
           return View(memberClassViewModel);
        }










       
        [HttpGet]
        public async Task<ActionResult> BookClassConfirmed(int id, int ClassId)  //firstid parameter is memberID
        {
            if (_context.Members.Any(x => x.Id == id))  //check if that memberID actually exists, else return 404 not found
            {

                var memberid = _context.Members.First(x => x.Id == id);
                var classid = _context.Classes.First(x => x.Id == ClassId);

               //ar classesbooked = _context.ClassesBooked;

                classid.NumberOfBookings = classid.NumberOfBookings + 1;
                //classid.MemberID.Add(memberid);

                _context.ClassesBooked.Add(new ClassesBooked { ClassID = ClassId, MemberID = id });
                    
                 
                _context.SaveChanges();


               

            }

            else
            {
                throw new HttpException(404, "Something has gone wrong");

            }




            TempData["Message"] = "Your class was successfully booked!";
            return RedirectToAction("Details",new { id = id });
        }


        [HttpGet]
        public async Task<IActionResult> CancelClass(int id)
        {




            //
            List<MemberClassViewModel> memberClassViewModel = new List<MemberClassViewModel>(); //declared my VIewModel instance

            var listData = await (from classessbooked in _context.ClassesBooked
                                  join classes in _context.Classes on classessbooked.ClassID equals classes.Id
                                  where (classessbooked.MemberID == id)

                                  select new MemberClassViewModel
                                  {
                                      ClassID = classessbooked.Id,
                                      ClassName = classes.ClassName,
                                      MemberID = id
                                  }
                                  ).ToListAsync();

            //listData.First().MemberIDs = (from member in _context.Members
            //                              join classesbooked in _context.ClassesBooked on member.Id equals classesbooked.MemberID
            //                              where id == classesbooked.ClassID
            //                              select new { member.Id })
            //                                       .Select(x => x.Id).ToList();

            listData.ForEach(x =>
            {
                MemberClassViewModel Obj = new MemberClassViewModel();
                Obj.ClassID = x.ClassID;
                Obj.ClassName = x.ClassName;
                Obj.MemberID = x.MemberID;


                memberClassViewModel.Add(Obj);


            }
            );


            return View(memberClassViewModel);
        }


        [HttpGet]
        public async Task<ActionResult> CancelClassConfirmed(int id, int ClassId)  //firstid parameter is memberID
        {
            if (_context.Members.Any(x => x.Id == id))  //check if that memberID actually exists, else return 404 not found
            {

                var memberid = _context.Members.First(x => x.Id == id);

                var classToRemove = _context.ClassesBooked.Where(c => c.Id == ClassId).SingleOrDefault();

                _context.ClassesBooked.Remove(classToRemove);
                _context.Entry(classToRemove).State = EntityState.Deleted;
                _context.SaveChanges();

                 
            }

            else
            {
                throw new HttpException(404, "Something has gone wrong");

            }



            TempData["Message"] = "Your class was successfully cancelled!";
            return RedirectToAction("Details", new { id = id });
        }





        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberViewModel member)//[Bind("Id,FirstName,LastName,DateOfBirth,PaymentType")] 
        {
            if (ModelState.IsValid)
            {
                var membershipTypeId = 1;

                
              

                if (_context.MembershipTypes.Any(x => x.MembershipTypeId.ToString() == member.PaymentType))
                {
                    
                    membershipTypeId = _context.MembershipTypes.First(x => x.MembershipTypeId.ToString() == member.PaymentType).MembershipTypeId;
                }
                var memberEntity = new Member
                {
                    DateOfBirth = member.DateOfBirth,
                    FirstName = member.FirstName,
                    Id = member.MemberID,
                    LastName = member.LastName,
                    TelephoneNumber = member.TelephoneNumber,
                    MembershipTypeId = membershipTypeId
                };
                _context.Members.Add(memberEntity);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Member has been created!";
                return RedirectToAction(nameof(Index));
            }

            
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.SingleOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //@Html.TextBox("datetimepicker")
       // @Html.TextBoxFor(model => model.DateOfBirth, "{0:dd/MMM/yyyy}", new { @class = "form-control datepicker" })

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                try
                {
                    _context.Members.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .SingleOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.SingleOrDefaultAsync(m => m.Id == id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Member has been successfully deleted!";
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
