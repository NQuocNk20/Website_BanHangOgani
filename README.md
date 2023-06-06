# BanHangOgani

#Download and open file script database QuanLiBanHang
# Run command:
# create database QuanLiBanHang
# and excute

# connect database to asp.net in visual studio via commnad: 
` "Scaffold-DBContext "Server=yourServer;uid=user;password=pass;database=YourDatabase;Encrypt=true;TrustServerCertificate=true" Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models" ` <br/> 
<br/> 
ex:"Scaffold-DBContext "Server=.;uid=sa;password=1;database=GlobalToyz;Encrypt=true;TrustServerCertificate=true" Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models"

#If have some changed from database SQL Server using command: <br/>

` "Scaffold-DBContext "Server=.;uid=sa;password=1;database=GlobalToyz;Encrypt=true;TrustServerCertificate=true" Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models -f" `
