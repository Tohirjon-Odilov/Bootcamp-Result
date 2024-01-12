namespace _22_lesson_httpclient_post_patch_delete_put
{
        public record class TodosMadel
        (
            int? userId = null,
            int? id = null,
            string? title = null,
            bool? completed = null
        );

    /*
     {
    "userId": 1,
    "id": 1,
    "title": "delectus aut autem",
    "completed": false
  },
     */
}
