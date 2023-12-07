using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;
using NguyenThanhTri.Library;

namespace _63CNTT5N1.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        SuppliersDAO suppliersDAO = new SuppliersDAO();
        ProductsDAO productsDAO = new ProductsDAO();
        MenusDAO menusDAO = new MenusDAO();
        /// /////////////////////////////////////////////////////////////
        // GET: Admin/Menu/Index
        public ActionResult Index()
        {
            ViewBag.CatList = categoriesDAO.getList("Index");
            ViewBag.SupList = suppliersDAO.getList("Index");
            ViewBag.ProList = productsDAO.getList("Index");
            return View(menusDAO.getList("Index"));
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //Them Loai san pham
            if (!string.IsNullOrEmpty(form["ThemCategory"]))
            {
                //kiem tra dau check cua muc con
                if (!string.IsNullOrEmpty(form["nameCategory"]))
                {
                    var listitem = form["nameCategory"];
                    //chuyen danh sach thanh dang mang: 1,2,3,4...
                    var listarr = listitem.Split(',');//ngat mang thanh tung phan tu cach nhau boi dau ,
                    foreach (var row in listarr)
                    {
                        int id = int.Parse(row);//ep kieu int
                        //lay 1 ban ghi
                        Categories categories = categoriesDAO.getRow(id);
                        //ta ra menu
                        Menus menu = new Menus();
                        menu.Name = categories.Name;
                        menu.Link = categories.Slug;
                        menu.TypeMenu = "category";
                        menu.Position = form["Position"];
                        menu.ParentID = 0;
                        menu.Order = 0;
                        menu.CreateAt = DateTime.Now;
                        menu.CreateBy = Convert.ToInt32(Session["UserID"].ToString());
                        menu.UpdateAt = DateTime.Now;
                        menu.UpdateBy = Convert.ToInt32(Session["UserID"].ToString());
                        menu.Status = 2; //tam thoi chua xuat ban
                        //Them vao DB
                        menusDAO.Insert(menu);
                    }
                    TempData["message"] = new XMessage("success", "Thêm vào menu thành công");
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn danh mục loại sản phẩm");
                }
            }

            //Them Nha cung cap
            if (!string.IsNullOrEmpty(form["ThemSupplier"]))
            {
                //kiem tra dau check cua muc con
                if (!string.IsNullOrEmpty(form["nameSupplier"]))
                {
                    var listitem = form["nameSupplier"];
                    //chuyen danh sach thanh dang mang: 1,2,3,4...
                    var listarr = listitem.Split(',');//ngat mang thanh tung phan tu cach nhau boi dau ,
                    foreach (var row in listarr)
                    {
                        int id = int.Parse(row);//ep kieu int
                        //lay 1 ban ghi
                        Suppliers suppliers = suppliersDAO.getRow(id);
                        //ta ra menu
                        Menus menu = new Menus();
                        menu.Name = suppliers.Name;
                        menu.Link = suppliers.Slug;
                        menu.TypeMenu = "supplier";
                        menu.Position = form["Position"];
                        menu.ParentID = 0;
                        menu.Order = 0;
                        menu.CreateAt = DateTime.Now;
                        menu.CreateBy = Convert.ToInt32(Session["UserID"].ToString());
                        menu.UpdateAt = DateTime.Now;
                        menu.UpdateBy = Convert.ToInt32(Session["UserID"].ToString());
                        menu.Status = 2; //tam thoi chua xuat ban
                        //Them vao DB
                        menusDAO.Insert(menu);
                    }
                    TempData["message"] = new XMessage("success", "Thêm vào menu thành công");
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn nhà cung cấp");
                }
            }

            //Them San pham
            if (!string.IsNullOrEmpty(form["ThemProduct"]))
            {
                //kiem tra dau check cua muc con
                if (!string.IsNullOrEmpty(form["nameProduct"]))
                {
                    var listitem = form["nameProduct"];
                    //chuyen danh sach thanh dang mang: 1,2,3,4...
                    var listarr = listitem.Split(',');//ngat mang thanh tung phan tu cach nhau boi dau ,
                    foreach (var row in listarr)
                    {
                        int id = int.Parse(row);//ep kieu int
                        //lay 1 ban ghi
                        Products products = productsDAO.getRow(id);
                        //ta ra menu
                        Menus menu = new Menus();
                        menu.Name = products.Name;
                        menu.Link = products.Slug;
                        menu.TypeMenu = "product";
                        menu.Position = form["Position"];
                        menu.ParentID = 0;
                        menu.Order = 0;
                        menu.CreateAt = DateTime.Now;
                        menu.CreateBy = Convert.ToInt32(Session["UserID"].ToString());
                        menu.UpdateAt = DateTime.Now;
                        menu.UpdateBy = Convert.ToInt32(Session["UserID"].ToString());
                        menu.Status = 2; //tam thoi chua xuat ban
                        //Them vao DB
                        menusDAO.Insert(menu);
                    }
                    TempData["message"] = new XMessage("success", "Thêm vào menu thành công");
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa chọn sản phẩm");
                }
            }

            //Them Custom
            if (!string.IsNullOrEmpty(form["ThemCustom"]))
            {
                //kiem tra dau check cua muc con
                if (!string.IsNullOrEmpty(form["nameCustom"]) && !string.IsNullOrEmpty(form["linkCustom"]))
                {
                    //tao ra menu custom
                    Menus menu = new Menus();
                    menu.Name = form["nameCustom"];
                    menu.Link = form["linkCustom"];
                    menu.TypeMenu = "custom";
                    menu.Position = form["Position"];
                    menu.ParentID = 0;
                    menu.Order = 0;
                    menu.CreateAt = DateTime.Now;
                    menu.CreateBy = Convert.ToInt32(Session["UserID"].ToString());
                    menu.UpdateAt = DateTime.Now;
                    menu.UpdateBy = Convert.ToInt32(Session["UserID"].ToString());
                    menu.Status = 2; //tam thoi chua xuat ban
                    //Them vao DB
                    menusDAO.Insert(menu);

                    TempData["message"] = new XMessage("success", "Thêm vào menu thành công");
                }
                else
                {
                    TempData["message"] = new XMessage("danger", "Chưa đầy đủ thông tin cho menu");
                }
            }

            //tra ve trang Index
            return RedirectToAction("Index", "Menu");
        }

        ////////////////////////////////////////////////////////////////
        //GET: Admin/Menu/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Menus menus = menusDAO.getRow(id);
            if (menus == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 1<->2
                menus.Status = (menus.Status == 1) ? 2 : 1;

                //cap nhat gia tri UpdateAt
                menus.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                menusDAO.Update(menus);

                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");

                return RedirectToAction("Index");
            }
        }


        ////////////////////////////////////////////////////////////////
        // GET: Admin/Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menus menus = menusDAO.getRow(id);
            if (menus == null)
            {
                return HttpNotFound();
            }
            return View(menus);
        }

        // GET: Admin/Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TableID,TypeMenu,Position,Link,ParentID,Order,CreateAt,CreateBy,UpdateAt,UpdateBy,Status")] Menus menus)
        {
            if (ModelState.IsValid)
            {
                menusDAO.Insert(menus);
                return RedirectToAction("Index");
            }

            return View(menus);
        }

        // GET: Admin/Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menus menus = menusDAO.getRow(id);
            if (menus == null)
            {
                return HttpNotFound();
            }
            return View(menus);
        }

        // POST: Admin/Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TableID,TypeMenu,Position,Link,ParentID,Order,CreateAt,CreateBy,UpdateAt,UpdateBy,Status")] Menus menus)
        {
            if (ModelState.IsValid)
            {
                menusDAO.Update(menus);
                return RedirectToAction("Index");
            }
            return View(menus);
        }

        // GET: Admin/Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menus menus = menusDAO.getRow(id);
            if (menus == null)
            {
                return HttpNotFound();
            }
            return View(menus);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menus menus = menusDAO.getRow(id);
            menusDAO.Delete(menus);
            return RedirectToAction("Index");
        }


        //////////////////////////////////////////////////////////////////////////////////////
        //DELTRAH
        // GET: Admin/Products/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Menus menus = menusDAO.getRow(id);
            if (menus == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Không tìm thấy mẩu tin");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 1,2 -> 0: Không hiển thị ở Index
                menus.Status = 0;

                //cap nhat gia tri UpdateAt
                menus.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                menusDAO.Update(menus);

                //thong bao cap nhat trang thai thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Xóa mẩu tin vào thùng rác thành công");

                return RedirectToAction("Index");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //TRASH: Luc thung rac
        // GET: Admin/Products/Trash
        public ActionResult Trash()
        {
            return View(menusDAO.getList("Trash"));
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //RECOVER
        // GET: Admin/Products/Recover/5
        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //truy van dong co id = id yeu cau
            Menus menus = menusDAO.getRow(id);
            if (menus == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            else
            {
                //chuyen doi trang thai cua Satus tu 0 -> 2: Khong xuat ban
                menus.Status = 2;

                //cap nhat gia tri UpdateAt
                menus.UpdateAt = DateTime.Now;

                //cap nhat lai DB
                menusDAO.Update(menus);

                //thong bao phuc hoi du lieu thanh cong
                TempData["message"] = TempData["message"] = new XMessage("success", "Phục hồi mẩu tin thành công");

                return RedirectToAction("Index");
            }
        }
    }
}
