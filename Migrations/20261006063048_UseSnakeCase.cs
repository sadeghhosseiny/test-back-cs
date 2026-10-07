using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersApi.Migrations
{
    /// <inheritdoc />
    public partial class UseSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "posts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "posts",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "posts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "posts",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "posts",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "posts",
                newName: "ix_posts_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_posts",
                table: "posts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_posts_users_user_id",
                table: "posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_posts_users_user_id",
                table: "posts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_posts",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Posts",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_posts_user_id",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
