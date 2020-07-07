using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebChess.Data;
using WebChess.Models;

namespace WebChess.Pages
{
    [Authorize]
    public class ChessModel : PageModel
    {
        public int Party { get; set; }
        public string UserBlack { get; set; }
        public string InitialDesk { get; set; }


        ApplicationDbContext dbContext;
        public ChessModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet()
        {
            var party = Request.Cookies.SingleOrDefault(s => s.Key == "party");
            if (party.Value == null) return RedirectToPage("/SelectParty");
            // check player
            Party = int.Parse(party.Value);
            var cp = await dbContext.ChessParties.SingleAsync(s => s.Id == Party);
            UserBlack = cp.UserBlack;
            var parties = await dbContext.DeskStates.Where(p => p.ChessPartyId == Party).ToArrayAsync();
            if (parties.Length != 0)
            {
                int last = parties.Max(s=>s.Id);//.LastOrDefault();
            } else
            {
                var desk = new ChessDesk();
                InitialDesk = System.Text.Json.JsonSerializer.Serialize(desk,new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                
            }
           
            return Page();
        }

        class moveData
        {
            public int row { get; set; }
            public int column { get; set; }
            public int destinationRow { get; set; }
            public int destinationColumn { get; set; }
        }

        public JsonResult OnPostMove(string row,string column,string destinationRow, string destinationColumn)
        {

            var desk = new ChessDesk();
            return new JsonResult(desk);

            //MemoryStream stream = new MemoryStream();
            //await Request.Body.CopyToAsync(stream);
            //stream.Position = 0;
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string requestBody = reader.ReadToEnd();
            //    if (requestBody.Length > 0)
            //    {
            //        var obj = JsonConvert.DeserializeObject<moveData>(requestBody);
            //        var col = obj.column;

            //    }
            //}

            //var a = 10;
        }

        public JsonResult OnGetDesk()
        {
            var desk = new ChessDesk();
            return new JsonResult(desk);

        }
    }
}