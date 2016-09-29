Use Test_System
go

Create table TestDetails(
Id char (10) primary key not null,
Question ntext,
Images ntext,
AnswerA ntext,
AnswerB ntext,
AnswerC ntext,
AnswerD ntext,
CorrectAnswer char,
TypeOfQuestion nvarchar(50),
Point float,
TestChildSubjectId char(10)
)
insert into TestDetails values (1,N'Những cái nào sau đây là thành phần của UML?',N'Mô Hình Activity',N'Mô hình Collaboration',N'Mô hình Sequence',N'Mô hình Use-case','A',1,0.25,'TCS002',1,1)
insert into TestDetails values ('TD2',N'Sự tách biệt giữa hệ thống và môi trường của nó là một ví dụ của?',null,N'System boundary',N'Automation boundary',N'Information boundary',N'Production boundary','B',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD3',N'Mối quan hệ <<include>> nghĩa là gì?',null,N'Giống như một thủ tục con, nó là một use case được sử dụng bởi một use case',N'Vai trò được thể hiện bởi một người cụ thể khi người đó tương tác với hệ thống',N'Nhấn mạnh sự tuần tự hoặc thứ tự các thông điệp. Một collaborationdiagram làm nổi bật tập hợp các đối tượng cộng tác cùng nhau để thực hiện mộtuse case',N'Giúp định rõ phạm vi hệ thống bằng cách nhận dạng các vai trò của tácnhân (actor) tương tác với hệ thống và một tập hợp các quyền và chức năng đượccung cấp cho các tác nhân đó.','B',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD4',N'Điều nào sau đây không phải là chức năng của giai đọan cần thiết cho xây dựngmột hệ cơ sở dữ liệu?',null,N'Định rõ mẩu tin dữ liệu (data item).',N'Xác định các ràng buộc và quy tắc (rule).',N'Xây dựng mô hình dữ liệu.',N'Tất cả các câu trên là chức năng của giai đọan cần thiết đó
','D',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD5',N'Khi xây dựng một mô hình dữ liệu, mục đích chính là tạo ra một mô hình tốt nhất theo ý người dùng.',null,N'Đúng',N'Sai',null,null,'B',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD6',N'Một use case diagram là sự mở rộng của:',null,N'Bảng sự kiện',N'Mô hình ngữ cảnh (context).',N'Mô hình tuần tự (sequence).',N'Mô hình class.','A',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD7',N'Mô hình Collaboration: ',null,N'Mô hình thể hiện sự tuần tự của các thông điệp giữa các đối tượng trongsuốt một use case',N'Mô hình thể hiện các đối tượng cộng tác cùng nhau để thưc hiện một usecase',N'Mô hình collaboration hoặc mô hình sequence thể hiện sự tương tác giữacác đối tượng',N'Một mô hình thể hiện các vai trò khác nhau của user và cách thức các vaitrò đó sử dụng hệ thống','B',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD8',N'Sự thành công của một hệ thống thông tin phụ thuộc gần như hòan tòan vào chất lượng của nó khi được xem xét bởi....',null,N'phần mềm',N'thủ tục',N'thông tin',N'người dùng','D',N'Điền khuyết',0.25,'TCS1')
insert into TestDetails values ('TD9',N'....được dùng để nhóm các lớp lại với nhau để dễ sử dụng, bảo trìvà sử dụng lại.',null,N'Trạng thái (States)',N'Trường hợp sử dụng (Use Cases)',N'Mô hình Context',N'Gói (Packages)','D',N'Điền khuyết',0.25,'TCS1')
insert into TestDetails values ('TD10',N'Xem xét mô hình Activity sau.Hãy xác định những họat động nào có thể xảy ra đồng thời?',N'images/Hinh1_Cau1_PTTKHDT.jpg',N'Request product, Receive order, Pay bill.',N'Receive order, Bill customer',N'Process order, Pull materials, Ship order, Bill customer, Pay bill.',N'Pay bill, Close order','B',N'Trắc nghiệm',0.25,'TCS1')
insert into TestDetails values ('TD11',N'Sơ đồ sau cho thấy các tình trạng của việc đăng ký của sinh viên trong hệ thốngHND. Câu nào sau đây không được thể hiện trong sơ đồ?',N'images/Hinh2_Cau11_PTTKHDT',N'Chỉ những sinh viên (student) trong trạng thái active mới có thể kết thúckhóa học và trở thành một HND tốt nghiệp (graduate)',N'Một sinh viên chỉ được phép bảo lưu một lần trong khóa học',N'Một sinh viên với tình trạng đăng ký đang họat động có thể thay đổi tìnhtrạng bằng việc bảo lưu, bỏ học, hoặc hòan thành khóa học.',N'Khi một sinh viên trong tình trạng bảo lưu quay trở lại khóa học, số đăng ký của họ họat động trở lại.','C',N'Trắc nghiệm',0.25,'TCS1')

-- Bảng chứa tiểu mục của một môn
Create table TestChildSubjects(
Id char(10) primary key not null,
TestChildSubjectId char(10),
SubjectCode char(10),
TestChildSujectName nvarchar(100),
TestSubjectId char(10)

)

insert into TestChildSubjects values (1,'TCS1','00001',N'Phân tích thiết kế giải thuật',1)
insert into TestChildSubjects values (2,'TCS2','00002',N'Phân tích thiết kế hệ thống thông tin',1)
insert into TestChildSubjects values (3,'TCS3','00003',N'Phân tích thiết kế hướng đối tượng',1)
insert into TestChildSubjects values (4,'TCS4','00004',N'Toán T3',2)
insert into TestChildSubjects values (5,'TCS5','000005',N'Toán rời rạc',2)

Create table TestSubjects(
Id char(10) primary key not null,
SubjectName nvarchar(100),
SubjectCode char(10),
NoOfEasyQuestion int,
NoOfMediumQuestion int,
NoOfHardQuestion int,
TestDate datetime,
TestTime int,
ResultId char(10),
TestMapId char(10)
)

insert into TestSubjects values (1,N'Phân tích','1',15,10,5,'9-18-2016 8:11','1:30:00')

insert into TestSubjects values (2,N'Toán','2',20,5,5,'7-22-2016 9:12','1:30:00')

insert into TestSubjects values (3,N'IQ','3',20,5,10,'7-21-2016 8:30','1:30:00')

insert into TestSubjects values (4,N'Ngôn ngữ','4',5,5,20,'8-30-2016 10:00','1:30:00')


