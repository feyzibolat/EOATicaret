﻿using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class CartController : Controller
    {

        db_EOAEntities1 db = new db_EOAEntities1();

        public ActionResult Index()
        {
            
            List<tblUrunler> cart = (List<tblUrunler>)Session["cart"];
            ViewBag.Cart = cart;
            return View();
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            // int gelenID = Convert.ToInt32(Request.QueryString["s"]);
            //var productId = Convert.ToInt32(urun["urunIdsi"]);
          
                    tblUrunler addToCart = db.tblUrunler.First(p => p.urunID == id);
                    if (Session["cart"] == null)
                    {
                        List<tblUrunler> cart = new List<tblUrunler>();
                        cart.Add(addToCart);
                        Session["cart"] = cart;
                    }
                    else
                    {
                        List<tblUrunler> cart = (List<tblUrunler>)Session["cart"];
                        cart.Add(addToCart);
                        Session["cart"] = cart;
                    }
                    return View("Index");
                
        }

        [HttpPost]
        public ActionResult DeleteToCart(int id)
        {
            tblUrunler tmpUrun = ((List<tblUrunler>)Session["cart"]).Where(u => u.urunID == id).First();

            List<tblUrunler> cart = new List<tblUrunler>();
            cart = (List<tblUrunler>)Session["cart"];
            cart.Remove(tmpUrun);
            if (cart.Count==0)
                Session["cart"] = null;
            else
                Session["cart"] = cart;

            return View("Index");
        }
    }
}