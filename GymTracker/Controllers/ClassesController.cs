using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymTracker.Data;
using GymTracker.Models;
using GymTracker.ViewModel;

namespace GymTracker.Controllers
{
    public class ClassesController : Controller
    {
        private readonly GymContext _context;

        public ClassesController(GymContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classes.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            List<MemberClassBookedViewModel> memberClassBookedViewModel = new  List<MemberClassBookedViewModel>(); //declared my VIewModel instance

            var listData = await (from classess in _context.Classes
                                  where (classess.Id == id)

                                  select new MemberClassBookedViewModel
                                  {
                                      ClassId = classess.Id,
                                      ClassName = classess.ClassName,
                                      ClassSize = classess.ClassSize,
                                      NumberOfBookings = classess.NumberOfBookings,
                                      MemberIDs = new List<int>()
                                  }
                                  ).ToListAsync();

            listData.First().MemberIDs = (from member in _context.Members
                                          join classesbooked in _context.ClassesBooked on member.Id equals classesbooked.MemberID
                                          where id == classesbooked.ClassID
                                          select new { member.Id })
                                                   .Select(x => x.Id).ToList();

            listData.ForEach(x =>
            {
                MemberClassBookedViewModel Obj = new MemberClassBookedViewModel();
                Obj.ClassId = x.ClassId;
                Obj.ClassName = x.ClassName;
                Obj.ClassSize = x.ClassSize;
                Obj.NumberOfBookings = x.NumberOfBookings;
                Obj.MemberIDs = x.MemberIDs;


                memberClassBookedViewModel.Add(Obj);


            }
            );

            return View(memberClassBookedViewModel);






            //var classes = await _context.Classes
            //    .SingleOrDefaultAsync(m => m.Id == id);
            //if (classes == null)
            //{
            //    return NotFound();
            //}

            //return View(classes);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassName,ClassSize,NumberOfBookings")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classes);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes.SingleOrDefaultAsync(m => m.Id == id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName,ClassSize,NumberOfBookings")] Classes classes)
        {
            if (id != classes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassesExists(classes.Id))
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
            return View(classes);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (classes == null)
            {
                return NotFound();
            }

            return View(classes);
        }

        //

















        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classes = await _context.Classes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassesExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
