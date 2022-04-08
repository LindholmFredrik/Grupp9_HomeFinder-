﻿using Microsoft.AspNetCore.Mvc;
using HomeFinder.Data; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;

namespace HomeFinder.Controllers
{
    public class GalleryController : Controller
    {
        private readonly HomeFinderContext _context; 
        public GalleryController(HomeFinderContext context)
        {
            _context = context; 
        }
        public async Task<IActionResult> Index(string searchTerm, string maxSlide, string minSlide, List<int> realEstateType, string removeFilter)
        {
            var realEstates = _context.RealEstate.Select(r => r);

            if (!string.IsNullOrEmpty(removeFilter) && removeFilter.Equals("Rensa filter"))
            {
                return View(await realEstates.ToListAsync());
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                realEstates = realEstates.Where(r => r.Address.Contains(searchTerm) || r.Description.Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(maxSlide))
            {
                int maxPrice = int.Parse(maxSlide);
                if(maxPrice != 0)
                {
                realEstates = realEstates.Where(r => r.Price <= maxPrice);
                }
            }
            if (!string.IsNullOrEmpty(minSlide))
            {
                int minPrice = int.Parse(minSlide);

                if(minPrice != 0)
                {
                realEstates = realEstates.Where(r => r.Price >= minPrice);
                }
            }
            if(realEstateType.Count > 0)
            {

                if (realEstateType.Count == 1)
                {
                    realEstates = realEstates.Where(r => (int)r.RealEstateType == realEstateType.ElementAt(0));
                }

                if(realEstateType.Count == 2)
                {
                    realEstates = realEstates.Where(r => (int)r.RealEstateType == realEstateType.ElementAt(0) || (int)r.RealEstateType == realEstateType.ElementAt(1));
                }

                if (realEstateType.Count == 3)
                {
                    realEstates = realEstates.Where(r => (int)r.RealEstateType == realEstateType.ElementAt(0) 
                    || (int)r.RealEstateType == realEstateType.ElementAt(1)
                    || (int)r.RealEstateType == realEstateType.ElementAt(2));
                }
            }

            return View(await realEstates.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {   
            if (id == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstate.Include(x => x.RealEstateImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }

    }
}
