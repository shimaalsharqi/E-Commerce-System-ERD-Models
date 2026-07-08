using E_CommerceSystem.Models;

namespace E_CommerceSystem
{
    public class Program
    {
        //  Static in-memory context
        public static ECommerceContext context = new ECommerceContext();

        // 1 Register a New User Function
        public static void RegisterUser()
        {
            // User information
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Full Name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            // Create new user object
            User newUser = new User
            {
                username = username,
                email = email,
                passwordHash = password,
                fullName = fullName,
                phoneNumber = phoneNumber,
                address = address,

                // System generated values
                registrationDate = DateTime.Now,
                isActive = true
            };

            // Add user to database
            context.Users.Add(newUser);

            // Save changes
            context.SaveChanges();

            // Display generated ID
            Console.WriteLine("User Registered Successfully");
            Console.WriteLine("Assigned User ID: " + newUser.userId);
        }
        //2  Add a New Product Function
        public static void AddProduct()
        {
            // Check if there are categories
            if (context.Categories.Count() == 0)
            {
                Console.WriteLine("No categories found So Please add a category first");
                return;
            }

            // Display all categories
            Console.WriteLine("Available Categories:");
            foreach (var category in context.Categories)
            {
                Console.WriteLine(category.categoryId + " - " + category.categoryName);
            }

            // Read product information
            Console.WriteLine("Enter Category ID:");
            int categoryId = int.Parse(Console.ReadLine());
            //check the Category ID 
            bool categoryIDFound = context.Categories.Any(a => a.categoryId == categoryId);
            if (categoryIDFound == false)
            {
                Console.WriteLine("The category Id not avilable");
                return;
            }


            Console.WriteLine("Enter Product Name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Price:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Stock Quantity:");
            int stockQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Image URL:");
            string imageUrl = Console.ReadLine();

            // Create new product object
            Product newProduct = new Product
            {
                categoryId = categoryId,
                productName = productName,
                description = description,
                price = price,
                stockQuantity = stockQuantity,
                imageUrl = imageUrl,

                // System generated values
                createdAt = DateTime.Now,
                isAvailable = true
            };

            // Add product to database
            context.Products.Add(newProduct);

            // Save changes
            context.SaveChanges();

            Console.WriteLine("Product Added Successfully");
            Console.WriteLine("Product ID: " + newProduct.productId);
        }
        // 3 Place a New Order Function
        public static void PlaceOrder()
        {
            // Check if there are users
            if (context.Users.Count() == 0)
            {
                Console.WriteLine("No users found");
                return;
            }

            // Check if there are products
            if (context.Products.Count() == 0)
            {
                Console.WriteLine("No products available");
                return;
            }

            // Display users
            Console.WriteLine("Users:");
            foreach (var user in context.Users)
            {
                Console.WriteLine(user.userId + " - " + user.fullName);
            }

            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());

            //check the User ID 
            bool userIdFound = context.Users.Any(a => a.userId == userId);
            if (userIdFound == false)
            {
                Console.WriteLine("The user Id not avilable");
                return;
            }

            Console.WriteLine("Enter Shipping Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Payment Method:");
            string payment = Console.ReadLine();

            // Create order
            Order newOrder = new Order()
            {
                userId = userId,
                orderDate = DateTime.Now,
                shippingAddress = address,
                paymentMethod = payment,
                status = "Pending",
                totalAmount = 0
            };

            // Add  new order to DB
            context.Orders.Add(newOrder);
            context.SaveChanges();

            decimal total = 0;
            string choice = "y";

            while (choice.ToLower() == "y")
            {
                // Display products
                Console.WriteLine("Available Products:");

                foreach (var prod in context.Products)
                {
                    Console.WriteLine(prod.productId + " - " +
                                      prod.productName +
                                      " Price: " + prod.price +
                                      " Stock: " + prod.stockQuantity);
                }

                Console.WriteLine("Enter Product ID:");
                int productId = int.Parse(Console.ReadLine());
                //Check if Product is found
                Product product = context.Products.FirstOrDefault(a=>a.productId== productId);

                if (product ==null)
                {
                    Console.WriteLine("Product not found");
                    return;
                }

                Console.WriteLine("Enter Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity > product.stockQuantity)
                {
                    Console.WriteLine("Not enough stock.");
                    return;
                }

                // Create order item
                OrderItem item = new OrderItem()
                {
                    orderId = newOrder.orderId,
                    productId = product.productId,
                    quantity = quantity,
                    unitPrice = product.price
                };

                context.OrderItems.Add(item);

                // Calculate total
                total += product.price * quantity;

                // Update stock
                product.stockQuantity -= quantity;

                Console.WriteLine("Add another product? (y/n)");
                choice = Console.ReadLine();
            }

            // Update order total
            newOrder.totalAmount = total;

            // Save all changes
            context.SaveChanges();

            Console.WriteLine("Order placed successfully.");
            Console.WriteLine("Order ID: " + newOrder.orderId);
            Console.WriteLine("Total Amount: " + newOrder.totalAmount);
        }
        // 4 Write a Product Review Function
        public static void WriteProductReview()
        {
            // Check if there are users
            if (context.Users.Count() == 0)
            {
                Console.WriteLine("No users found");
                return;
            }

            // Check if there are products
            if (context.Products.Count() == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            // Display users
            Console.WriteLine("Users:");
            foreach (var user in context.Users)
            {
                Console.WriteLine(user.userId + " - " + user.fullName);
            }

            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            //check the User ID 
            bool userIdFound = context.Users.Any(a => a.userId == userId);
            if (userIdFound == false)
            {
                Console.WriteLine("The user Id not avilable");
                return;
            }
            // Display products
            Console.WriteLine("Products:");
            foreach (var product in context.Products)
            {
                Console.WriteLine(product.productId + " - " + product.productName);
            }

            Console.WriteLine("Enter Product ID:");
            int productId = int.Parse(Console.ReadLine());
            //check the Product ID
            bool productIdFound = context.Products.Any(a => a.productId == productId);
            if (productIdFound == false)
            {
                Console.WriteLine("The Product Id not avilable");
                return;
            }

            Console.WriteLine("Enter Rating (1-5):");
            int rating = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Comment:");
            string comment = Console.ReadLine();

            // Create review object
            Review newReview = new Review()
            {
                userId = userId,
                productId = productId,
                rating = rating,
                comment = comment,
                reviewDate = DateTime.Now
            };

            // Add review to database
            context.Reviews.Add(newReview);

            // Save changes
            context.SaveChanges();

            Console.WriteLine("Review Added Successfully");
            Console.WriteLine("Review ID: " + newReview.reviewId);
        }
        // 5 Update Product Price and Availability Function
        public static void UpdateProduct()
        {
            // Check if there are products
            if (context.Products.Count() == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            // Display all products
            Console.WriteLine("Products:");
            foreach (var product in context.Products)
            {
                Console.WriteLine(product.productId + " - " +
                                  product.productName +
                                  " Price: " + product.price +
                                  " Available: " + product.isAvailable);
            }

            Console.WriteLine("Enter Product ID:");
            int productId = int.Parse(Console.ReadLine());

            //Check if Product is found
            Product productToUpdate = context.Products.FirstOrDefault(a => a.productId == productId);

            if (productToUpdate == null)
            {
                Console.WriteLine("Product not found");
                return;
            }

            // Read new price
            Console.WriteLine("Enter New Price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            // Read availability
            Console.WriteLine("Is Product Available? (true/false)");
            bool availability = bool.Parse(Console.ReadLine());

            // Update product
            productToUpdate.price = newPrice;
            productToUpdate.isAvailable = availability;

            // Save changes
            context.SaveChanges();

            Console.WriteLine("Product Updated Successfully");
        }
        // 6 Cancel an Order Function
        public static void CancelOrder()
        {
            // Check if there are orders
            if (context.Orders.Count() == 0)
            {
                Console.WriteLine("No orders found");
                return;
            }

            // Display all orders
            Console.WriteLine("Orders:");
            foreach (var ord in context.Orders)
            {
                Console.WriteLine("Order ID: " + ord.orderId +
                                  " | Status: " + ord.status);
            }

            Console.WriteLine("Enter Order ID:");
            int orderId = int.Parse(Console.ReadLine());

            // Check
            Order order = context.Orders.FirstOrDefault(o => o.orderId == orderId);

            if (order == null)
            {
                Console.WriteLine("Order not found");
                return;
            }

            // Check if the order is already cancelled
            if (order.status == "Cancelled")
            {
                Console.WriteLine("Order is already cancelled");
                return;
            }

            // Get all order items
            List<OrderItem> items = context.OrderItems
                                           .Where(i => i.orderId == orderId)
                                           .ToList();

            // Restore product stock
            foreach (var item in items)
            {
                Product product = context.Products
                                         .FirstOrDefault(p => p.productId == item.productId);

                if (product != null)
                {
                    product.stockQuantity += item.quantity;
                }
            }

            // Update order status
            order.status = "Cancelled";

            // Save changes
            context.SaveChanges();

            Console.WriteLine("Order Cancelled Successfully");
        }
        static void Main(string[] args)
        {
            bool stop = false;

            while (stop == false)
            {
                //the  menu of the system 

                Console.WriteLine("=====================================");
                Console.WriteLine("     E-Commerce Management System");
                Console.WriteLine("=====================================");
                Console.WriteLine("1- Register New User");
                Console.WriteLine("2- Add New Product");
                Console.WriteLine("3- Place Order");
                Console.WriteLine("4- Write Product Review");
                Console.WriteLine("5- Update Product Price and Availability");
                Console.WriteLine("6- Cancel Order");
                Console.WriteLine("0- Exit");
                Console.WriteLine("=====================================");
                Console.Write("Enter your choice: ");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RegisterUser(); 
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        PlaceOrder();
                        break;
                    case 4:
                        WriteProductReview();
                        break;
                    case 5:
                        UpdateProduct();
                        break;
                    case 6:
                        CancelOrder();
                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:

                        break;
                    case 0:

                        break;

                }

                //To clear the cosole page 
                Console.WriteLine("Please press any key ...");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
