using EpreuveIzabela.DAL.Models;
using EpreuveIzabela.DAL.Repositories;
using EpreuveIzabela.Models;
using EpreuveIzabela.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpreuveIzabela.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        [HttpPost]
        //pour voir si on parle avec le bon formulaire step 1
        [ValidateAntiForgeryToken]
        //HttpPostedFileBase le nom de variable doit etre le meme que dans le model!!!
        public ActionResult Register(RegisterModel Rm, HttpPostedFileBase PhotoUser)
        {
            if (PhotoUser != null)
            {
                //HttpPostedFileBase - Use to retrieve picture uploaded from form
                //We have to verify the mime type and the image size
                List<string> matchContentType = new List<string>() { "image/jpeg", "image/jpg", "image/png", "image/gif" };
                // ici on a du metre image / jpeg; si on aurait verifier apres le point on aurait mis jpeg directement -MIME types
                if (!matchContentType.Contains(PhotoUser.ContentType) || PhotoUser.ContentLength > 1200000)
                {
                    ViewBag.ErrorMessage = "Le fichier ne possède pas une extension autorisée (png, jpg,gif)";
                    return View("Index");
                }
            }
            //We can't save the file before to save the member in the database

            //Check if data annotations are respected ==> See the RegisterModel Class
            if (!ModelState.IsValid)
            {
                //I want to get all error on the model like wrong email format, wrong password repetiton,....
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        //add the error message into a viewbag to display on the view
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br>";
                    }
                }
            }
            else
            {
                MembreRepository Mr = new MembreRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
                //I have to call the Insert function from MembreRepository
                //If the insert succeed, we get a complete Member with id value (calculated by the database)
                //If the insert failed, we receive a null value
                //We have to convert the registerModel(viewmodel) to a MembreModel(Dal) before to call the function
                // this is why we call the static function RegisterToMembre from the Static lass MapToDBModel
                if (PhotoUser != null)
                {
                    Rm.PhotoUser = PhotoUser.FileName;
                }

                Membre M = Mr.Insert(MapToDBModel.RegisterToMembre(Rm));
                if (M != null)
                {
                    if (PhotoUser != null)
                    {
                        //Now I can save the picture
                        //1 - Get the filename and extract the extension
                        string[] splitFileName = PhotoUser.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        string ext = splitFileName[splitFileName.Length - 1]; //Get the last collumn of the array which contains the extension of the picture

                        //2- Generate the new file name
                        string newFileName = M.Id + "." + ext;

                        //3- Save the picture
                        //3.1 - Get the physic path of the photos folder
                        string folderpath = Server.MapPath("~/photos/");
                        //3.2 - Combine folder path and new filename
                        string FileNameToSave = folderpath + "/" + newFileName;
                        //3.3 - Save

                        try
                        {
                            //SaveAs is a procedure and not a function thus we have to surround with try catch to
                            // get error if the SaveAs failed
                            PhotoUser.SaveAs(FileNameToSave);
                        }
                        catch (Exception)
                        {
                            ViewBag.ErrorMessage = "L'image n'a pas pu être sauvée";
                            throw;
                        }

                    }

                    //I want to pre-fill the login html input if the register succeed.
                    //Thus , I use ViewBag to store the Email and a success message to communicate with the guest
                    //ViewBag.Login = Rm.Login;
                    ViewBag.SuccessMessage = "Vous pouvez vous connecter";
                    return RedirectToAction("Login", new { controller = "Login", area = ""});

                }
                else
                {
                    //If there is an issuer, I want to dispay a message on the view.
                    //Thus I use Viewbag to send the message to the view
                    ViewBag.ErrorMessage = "Error de register";
                    return RedirectToAction("Register", new { controller = "Register", area = "" });
                }

                
            }
            return RedirectToAction("Index", new { controller = "Home", area = "" });


        }
    }
}