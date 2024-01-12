namespace _22_lesson_httpclient_post_patch_delete_put
{
        public record class UsersMadel
        (
            int? id = null,
            string? name = null,
            string? username = null,
            string? email = null,
            string? address = null,
            string? phone = null,
            string? website = null,
            string? company = null
        );

    /*
    {
    "id": 1,
    "name": "Leanne Graham",
    "username": "Bret",
    "email": "Sincere@april.biz",
    "address": {
      "street": "Kulas Light",
      "suite": "Apt. 556",
      "city": "Gwenborough",
      "zipcode": "92998-3874",
      "geo": {
        "lat": "-37.3159",
        "lng": "81.1496"
      }
    },
    "phone": "1-770-736-8031 x56442",
    "website": "hildegard.org",
    "company": {
      "name": "Romaguera-Crona",
      "catchPhrase": "Multi-layered client-server neural-net",
      "bs": "harness real-time e-markets"
    }
  },
     */
}
