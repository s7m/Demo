# Demo
A demo application for keeping Company record specifying the Name, Stock Ticker, Exchange, ISIN, and optionally a website URL

# For Running the application succesfully in local machine, follow the steps,
1. Run the API project first and copy the url
2. Go to the client and update the base url inside the environment.ts file, if it is different
3. Run the angular client using ng serve command
4. To add or search company, login using the credentials given below,
    username: user1
    password: pass123
5. If you get any cors errror, open the startup.cs on the API project and update the code 
                opt.AddPolicy("CorsPolicy", policy =>
                 {
                     policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                 });
    with the client url
-----
    
