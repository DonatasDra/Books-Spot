# Books-Spot
Book manager for Books Spot library

Books Spot is a webapp created in order to help users easily reserve/borrow books from Books Spot library.

Books Spot is based on Razor Pages and LocalDB (SQL Server) meaning, that upon building the app a database will be created and stored locally. Relevant migrations are applied and databases created automatically upon building the app. The data will be seeded to the database from Models/SeedData.cs

The app itself runs locally.

!Upon building, the first created account will have administrative rights, meaning that this account will be able to edit/delete and add new books to the database.

Administrator can also view who reserved which book and change its status to borrowed upon borrowing it.

!All further created accounts will not have administrative rights and will only be able to reserve books.

Additional features that could be added:

1. Add email confirmations/password recovery and registration/logging in via external authentication services.
2. Create user friendly and well looking UI (currently the UI is completely basic).
3. Limit amount of possible reservations for single user.
4. Remove reservation button for books which are already reserved/borrowed.
5. Add portal for users(and administator) where they could track their(or their users) borrowed/reserved books and time when they need to return it.
6. Make UI more friendly for different width devices.
