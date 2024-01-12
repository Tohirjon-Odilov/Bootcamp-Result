namespace _22_lesson_httpclient_post_patch_delete_put
{
        public record class PhotosMadel
        (
            int? albumId = null,
            int? id = null,
            string? title = null,
            string? url = null,
            string? thumbnailUrl = null
        );

    /*
     {
    "albumId": 1,
    "id": 1,
    "title": "accusamus beatae ad facilis cum similique qui sunt",
    "url": "https://via.placeholder.com/600/92c952",
    "thumbnailUrl": "https://via.placeholder.com/150/92c952"
  },
     */
}
