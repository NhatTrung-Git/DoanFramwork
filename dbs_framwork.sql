-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 13, 2022 at 08:50 AM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbs_framwork`
--

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `cart_id` int(11) NOT NULL,
  `customer_id` int(10) UNSIGNED NOT NULL,
  `product_id` int(10) UNSIGNED NOT NULL,
  `cart_quantity` int(11) NOT NULL,
  `cart_price` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`cart_id`, `customer_id`, `product_id`, `cart_quantity`, `cart_price`) VALUES
(22, 1, 2, 4, '5000000'),
(23, 1, 3, 4, '8000000'),
(24, 1, 4, 3, '12000000');

-- --------------------------------------------------------

--
-- Table structure for table `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(19, '2014_10_12_000000_create_users_table', 1),
(20, '2014_10_12_100000_create_password_resets_table', 1),
(21, '2019_06_11_145812_create_tbl_admin_table', 1),
(22, '2019_06_17_161852_create_tbl_category_product', 1),
(23, '2019_06_19_152045_create_tbl_brand_product', 1),
(24, '2019_06_19_155204_create_tbl_product', 1),
(25, '2019_08_17_030852_tbl_customer', 1),
(26, '2019_08_17_044054_tbl_shipping', 2),
(30, '2019_08_28_142718_tbl_payment', 3),
(31, '2019_08_28_142750_tbl_order', 3),
(32, '2019_08_28_142810_tbl_order_details', 3);

-- --------------------------------------------------------

--
-- Table structure for table `password_resets`
--

CREATE TABLE `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `admin_id` int(10) UNSIGNED NOT NULL,
  `admin_email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `admin_password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `admin_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `admin_phone` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`admin_id`, `admin_email`, `admin_password`, `admin_name`, `admin_phone`, `created_at`, `updated_at`) VALUES
(1, 'admin@gmail.com', 'admin123', 'admin', '0335750889', '2022-01-04 09:53:54', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_brand`
--

CREATE TABLE `tbl_brand` (
  `brand_id` int(10) UNSIGNED NOT NULL,
  `brand_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `brand_image` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `brand_desc` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `brand_status` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_brand`
--

INSERT INTO `tbl_brand` (`brand_id`, `brand_name`, `brand_image`, `brand_desc`, `brand_status`, `created_at`, `updated_at`) VALUES
(1, 'Sony', 'https://www.sony.net/top/2017/img/icon/top-og.jpg', 'Công ty công nghiệp Sony', 1, '2022-01-13 00:55:26', '2022-01-13 07:13:24'),
(2, 'Samsung', 'https://1000logos.net/wp-content/uploads/2017/06/Logo-Samsung.png', 'Samsung cam kết tuân thủ luật pháp', 1, '2022-01-11 07:49:06', '2022-01-13 07:14:09'),
(3, 'Acer', 'https://upload.wikimedia.org/wikipedia/commons/8/8b/Acer-logo.jpg', 'Acer nhà cung cấp hàng đầu Việt Nam', 0, '2022-01-12 01:03:08', '2022-01-21 01:03:08'),
(4, 'Asus', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1LKV671MUgggFiSKFASZI2_neMlfJ45Y4Fw&usqp=CAU', 'Asus luôn luôn hiện hữu khi bạn cần', 0, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(5, 'MSI', 'https://www.playzone.vn/image/catalog/logo%20hang/msi/MSI-Gaming-Logo-Horizontal.jpg', 'MSI luôn được tin tưởng hoàn toàn bởi khách hàng', 1, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(6, 'Phong Vũ', 'https://canthoplus.com/wp-content/uploads/2019/06/phong-v%C5%A9-c%E1%BA%A7n-th%C6%A1.jpg', 'Phong Vũ bạn của mọi nhà', 0, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(7, 'Hanoi Computer', 'https://1ty.vn/datafiles/3/2018-06-09/hanoicomputer-logo-15284837823775.jpg', 'Hanoi Computer mang lại sự tin tưởng tuyệt đối ', 1, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(8, 'Hp', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/HP_logo_2012.svg/1200px-HP_logo_2012.svg.png', 'Hp sự phục vụ chu đáo', 0, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(9, 'Nokia', 'https://thietkethuonghieu.net/Data/images/kien-thuc-thuong-hieu/nokia-connecting-people.jpg', 'Nokia kết nối mọi người', 1, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(10, 'Apple', 'https://yt3.ggpht.com/ytc/AKedOLRIJUapgrkJHrdwFR7PNNxRQ4Ti-SE3cYFw8LymqQ=s900-c-k-c0x00ffffff-no-rj', 'Mang đến sự phục vụ tốt nhất', 1, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(11, 'Oppo', 'https://wallpaperaccess.com/full/4392106.jpg', 'Vui lòng khách đến vừa lòng khách đi', 1, '2022-01-04 01:07:29', '2022-01-31 01:07:29');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_category_product`
--

CREATE TABLE `tbl_category_product` (
  `category_id` int(10) UNSIGNED NOT NULL,
  `category_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `slug_category_product` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `category_desc` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `category_status` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_category_product`
--

INSERT INTO `tbl_category_product` (`category_id`, `category_name`, `slug_category_product`, `category_desc`, `category_status`, `created_at`, `updated_at`) VALUES
(1, 'Laptop', 'Lap', 'https://phucanhcdn.com/media/product/42442_surface_laptop_go_platinum_h1.png', 1, NULL, NULL),
(2, 'Máy quay phim', 'MQP', 'https://storage.googleapis.com/cdn.nhanh.vn/store1/42431/psCT/20191215/18700695/444.jpg', 1, NULL, NULL),
(3, 'Tivi', 'TV', 'https://cdn01.dienmaycholon.vn/filewebdmclnew/public//userupload/images/nhung-tinh-nang-doc-dao-it-nguoi-biet-tren-smart-tivi-samsung-1.png', 1, NULL, NULL),
(4, 'Tay cầm', 'TC', 'https://salt.tikicdn.com/cache/100x100/ts/product/66/e1/ea/31b082ec6d1a93d75fd219d776ca0d2c.jpg.webp', 1, NULL, NULL),
(5, 'Máy chơi game', 'MCG', 'http://vn.cn-hotitem.com/uploads/202022166/new-psp-emulator-games-for-android14050394216.jpg', 1, NULL, NULL),
(6, 'Chuột máy tính', 'CMT', 'https://www.dinhvangcomputer.vn/wp-content/uploads/2020/12/Chuot-may-tinh-DARE-U-EM908_TM205U08601G-1.jpg', 1, NULL, NULL),
(7, 'Quạt tản nhiệt', 'QTN', 'https://www.tmcrack.vn/vn/wp-content/uploads/2017/07/FAN120.jpg', 1, NULL, NULL),
(8, 'Router phát wifi', 'RPW', 'https://cdn.tgdd.vn/Products/Images/4727/247289/bo-phat-song-wifi-router-chuan-ac1200-tp-link-archer-c54-den-ava-600x600.png', 1, NULL, NULL),
(9, 'Đồ lót chuột', 'DLC', 'https://product.hstatic.net/1000026716/product/gearvn-lot-chuot-razer-firefly-v2-70_a5669e9f937b490e9febd39a3db7be53.jpg', 1, NULL, NULL),
(10, 'Card đồ họa', 'CDH', 'https://laptops.vn/uploads/check-graphics-cards-xfx-radeon-rx-580-gts-laptop-tran-phat_1591104975.jpg', 1, NULL, NULL),
(11, 'Bàn phím', 'BP', 'https://st.quantrimang.com/photos/image/2021/02/06/top-ban-phim-co-1.jpg', 1, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_customers`
--

CREATE TABLE `tbl_customers` (
  `customer_id` int(10) UNSIGNED NOT NULL,
  `customer_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `customer_email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `customer_password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `customer_phone` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `customer_address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_customers`
--

INSERT INTO `tbl_customers` (`customer_id`, `customer_name`, `customer_email`, `customer_password`, `customer_phone`, `customer_address`, `created_at`, `updated_at`) VALUES
(1, 'Trung', 'trung@gmail.com', '5923f33de279fed8e31358d923a53a29', '0335750999', 'Chau Mi', NULL, NULL),
(2, 'Trọng', 'trong@gmail.com', '25f9e794323b453885f5181f1b624d0b', '0985756251', 'Chau Thanh', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_order`
--

CREATE TABLE `tbl_order` (
  `order_id` bigint(20) UNSIGNED NOT NULL,
  `customer_id` int(11) NOT NULL,
  `voucher_id` int(11) DEFAULT NULL,
  `order_total` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `order_status` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `order_address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_order`
--

INSERT INTO `tbl_order` (`order_id`, `customer_id`, `voucher_id`, `order_total`, `order_status`, `order_address`, `created_at`, `updated_at`) VALUES
(1, 1, NULL, '20000000', 'Đã thanh toán', 'Chau Mi', '2021-12-16 07:17:53', '2022-01-13 07:25:04'),
(2, 1, 6, '19360000', 'Đang giao', 'Chau Mi', '2021-12-17 07:19:57', NULL),
(3, 1, 1, '46800000', 'Đã thanh toán', 'Chau Mi', '2021-11-11 07:20:21', '2022-01-13 07:25:05'),
(4, 1, 6, '139040000', 'Đang giao', 'Chau Mi', '2021-11-18 07:20:52', NULL),
(5, 1, NULL, '413600000', 'Đã hủy đơn', 'Chau Mi', '2021-11-10 07:21:59', '2022-01-13 07:25:06'),
(6, 2, 2, '40480000', 'Đang giao', 'Chau Thanh', '2021-10-22 07:22:22', NULL),
(7, 2, NULL, '301500000', 'Đang giao', 'Chau Thanh', '2021-10-12 07:22:52', NULL),
(8, 2, NULL, '91620000', 'Đang giao', 'Chau Thanh', '2021-10-11 07:23:23', NULL),
(9, 2, 7, '7360000', 'Đang giao', 'Chau Thanh', '2021-09-07 07:24:04', NULL),
(10, 2, 8, '99681600', 'Đang giao', 'Chau Thanh', '2021-09-15 07:24:37', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_order_details`
--

CREATE TABLE `tbl_order_details` (
  `order_details_id` bigint(20) UNSIGNED NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_price` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_sales_quantity` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_order_details`
--

INSERT INTO `tbl_order_details` (`order_details_id`, `order_id`, `product_id`, `product_name`, `product_price`, `product_sales_quantity`, `created_at`, `updated_at`) VALUES
(1, 1, 2, 'Máy PS4 màu đỏ', '5000000', 4, '2022-01-13 07:16:38', NULL),
(2, 2, 6, 'NINTENDO SWITCH LITE TURQUOISE', '4000000', 5, '2022-01-13 07:19:57', NULL),
(3, 2, 10, 'Máy chơi game gameboy color', '500000', 4, '2022-01-13 07:19:57', NULL),
(4, 3, 19, 'Tay Cầm Chơi Game Không Dây 5in1', '2000000', 5, '2022-01-13 07:20:21', NULL),
(5, 3, 56, 'Tivi Sharp 42 Inch 2T-C42BG1X ', '14000000', 3, '2022-01-13 07:20:21', NULL),
(6, 4, 26, 'Laptop Dell Latitude 3420', '30000000', 5, '2022-01-13 07:20:52', NULL),
(7, 4, 5, 'Nintendo switch', '2000000', 3, '2022-01-13 07:20:52', NULL),
(8, 4, 1, 'Tay cầm chơi game PS4 màu trắng', '500000', 4, '2022-01-13 07:20:52', NULL),
(9, 5, 40, 'Máy quay phim Full HD HC', '65000000', 4, '2022-01-13 07:21:59', NULL),
(10, 5, 26, 'Laptop Dell Latitude 3420', '30000000', 4, '2022-01-13 07:21:59', NULL),
(11, 5, 60, 'Smart Tivi Casper 32 inch 32HX6200', '30000000', 1, '2022-01-13 07:21:59', NULL),
(12, 5, 123, 'Bàn phím Alienware AW568', '900000', 4, '2022-01-13 07:21:59', NULL),
(13, 6, 4, 'Máy PS5 màu trắng', '12000000', 3, '2022-01-13 07:22:22', NULL),
(14, 6, 5, 'Nintendo switch', '2000000', 5, '2022-01-13 07:22:22', NULL),
(15, 7, 24, 'Tay cầm PS3 đen', '500000', 3, '2022-01-13 07:22:52', NULL),
(16, 7, 46, 'Máy quay Sony Pmw Ex1r', '100000000', 3, '2022-01-13 07:22:52', NULL),
(17, 8, 27, 'Laptop MSI core i5', '45000000', 2, '2022-01-13 07:23:23', NULL),
(18, 8, 64, 'Chuột máy tính MARVO M910', '540000', 3, '2022-01-13 07:23:23', NULL),
(19, 9, 3, 'Máy PS4 màu đen', '8000000', 1, '2022-01-13 07:24:04', NULL),
(20, 10, 30, 'Laptop MSI GF65 Thin 10UE-228VN', '43000000', 3, '2022-01-13 07:24:37', NULL),
(21, 10, 90, 'Bộ phát wifi Router Wifi Sony', '540000', 4, '2022-01-13 07:24:37', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product`
--

CREATE TABLE `tbl_product` (
  `product_id` int(10) UNSIGNED NOT NULL,
  `product_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_slug` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `category_id` int(11) NOT NULL,
  `brand_id` int(11) NOT NULL,
  `product_desc` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_content` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_price` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_image` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `product_status` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tbl_product`
--

INSERT INTO `tbl_product` (`product_id`, `product_name`, `product_slug`, `category_id`, `brand_id`, `product_desc`, `product_content`, `product_price`, `product_image`, `product_status`, `created_at`, `updated_at`) VALUES
(1, 'Tay cầm chơi game PS4 màu trắng', 'tay-cam-choi-game-ps4-mau-trang', 4, 2, 'Tay cầm chơi game PS4 màu trắng', 'Tay cầm chơi game PS4 màu trắng', '500000', 'https://hanoicomputercdn.com/media/product/37582_gamepad_sony_ps4_dualshock4_wireless_controller_trang_chinhhang_0002_1.jpg', 1, '2021-12-25 14:23:01', '2022-01-13 07:20:52'),
(2, 'Máy PS4 màu đỏ', 'may-ps4-mau-do', 5, 2, 'Máy PS4 màu đỏ', 'Máy PS4 màu đỏ', '5000000', 'https://file.hstatic.net/1000231532/file/mua_ps4_pro_spiderman_grande.jpg', 12, '2021-12-25 14:25:06', '2022-01-13 07:16:38'),
(3, 'Máy PS4 màu đen', 'may-ps4-mau-den', 5, 2, 'Máy PS4 màu đen', 'Máy PS4 màu đen', '8000000', 'https://salt.tikicdn.com/cache/280x280/ts/product/7d/95/f5/574bd8f21b82eeb3bdc7641944c652ea.jpeg', 99, '2022-01-12 01:03:08', '2022-01-13 07:24:04'),
(4, 'Máy PS5 màu trắng', 'may-ps5-mau-trang', 5, 1, 'Máy PS5 màu trắng', 'Máy PS5 màu trắng', '12000000', 'https://xachtayonline-vn.s3.ap-southeast-1.amazonaws.com/product_images/1605630243z5phk-may-choi-game-play-station-5-ps5-1.jpg', 26, '2022-01-12 01:03:08', '2022-01-13 07:22:22'),
(5, 'Nintendo switch', 'Nintendo switch', 5, 1, 'Nintendo switch', 'Nintendo switch', '2000000', 'https://cdn.vjshop.vn/hightech/may-choi-game/nintendo/nintendo-switch-v2/may-choi-game-nintendo-switch-1.jpg', 245, '2022-01-11 01:28:22', '2022-01-13 07:22:22'),
(6, 'NINTENDO SWITCH LITE TURQUOISE', 'NINTENDO SWITCH LITE TURQUOISE', 5, 1, 'NINTENDO SWITCH LITE TURQUOISE', 'NINTENDO SWITCH LITE TURQUOISE', '4000000', 'https://product.hstatic.net/1000231532/product/may_game_nintendo_switch_lite_turquoise_chinh_hang_865d04367d8543d59565e06719138045_master.png', 19, '2022-01-07 01:28:22', '2022-01-13 07:19:57'),
(7, 'Máy chơi game Nintendo Switch', 'Máy chơi game Nintendo Switch OLED White', 5, 2, 'Máy chơi game Nintendo Switch OLED White', 'Máy chơi game Nintendo Switch OLED White', '4500000', 'https://hanoicomputercdn.com/media/product/61005_may_choi_game_nintendo_switch_oled_white_trang_0002_3.jpg', 45, '2022-01-14 01:28:22', '2022-01-13 07:05:05'),
(8, 'Máy chơi game gameboy', 'Máy chơi game gameboy', 5, 1, 'Máy chơi game gameboy', 'Máy chơi game gameboy', '1500000', 'https://s3.cloud.cmctelecom.vn/tinhte2/2019/04/4627728_cover_home_gameboy_30_nam.jpg', 111, '2022-01-13 01:28:22', '2022-01-31 01:28:22'),
(9, 'Máy chơi game Gameboy 64 Bit', 'Máy chơi game cầm tay Gameboy 64 Bit', 5, 1, 'Máy chơi game cầm tay Gameboy 64 Bit', 'Máy chơi game cầm tay Gameboy 64 Bit', '2400000', 'https://fabiensanglard.net/another_world_polygons_GBA/gba.png', 43, '2022-01-20 01:28:22', '2022-01-13 07:09:17'),
(10, 'Máy chơi game gameboy color', 'Máy chơi game cầm tay gameboy color', 5, 2, 'Máy chơi game cầm tay gameboy color', 'Máy chơi game cầm tay gameboy color', '500000', 'https://1.bp.blogspot.com/--b8QQuUi_u8/X63baYGQiVI/AAAAAAAAMU4/olOMcOraNf8L-vJ6cWpQufxBsKLrd_7CQCLcBGAsYHQ/s1200/gameboy%2Bclo%2B4.jpg', 40, '2022-01-03 01:28:22', '2022-01-13 07:19:57'),
(11, 'Máy chơi game Gameboy Advance', 'Máy chơi game Gameboy Advance', 5, 1, 'Máy chơi game Gameboy Advance', 'Máy chơi game Gameboy Advance', '1200000', 'https://gamek.mediacdn.vn/zoom/700_438/133514250583805952/2020/4/28/7-su-that-khong-ngo-ve-game-boy-advance-1588007804673592753926.jpg', 67, '2022-01-04 01:28:22', '2022-01-31 01:28:22'),
(12, 'Máy chơi game Gameboy cute', 'Máy chơi game Gameboy cute', 5, 1, 'Máy chơi game Gameboy cute', 'Máy chơi game Gameboy cute', '3200000', 'https://cdn.tgdd.vn/Files/2019/11/30/1223517/9_1280x720-800-resize.jpg', 89, '2022-01-18 01:28:22', '2022-01-31 01:28:22'),
(13, 'Máy chơi game tay cầm', 'Máy chơi game tay cầm', 5, 1, 'Máy chơi game tay cầm', 'Máy chơi game tay cầm', '3000000', 'https://api.thinkview.vn/uploads/editor/nintendo-switch-tang-gia-4.jpg', 23, '2022-01-14 02:58:53', '2022-01-15 02:58:53'),
(14, 'TAY CẦM CHƠI GAME BLUIETOOTH', 'TAY CẦM CHƠI GAME BLUIETOOTH T3 ANDROI', 4, 1, 'TAY CẦM CHƠI GAME BLUIETOOTH T3 ANDROI', 'TAY CẦM CHƠI GAME BLUIETOOTH T3 ANDROI', '3000000', 'https://thachlongtech.com/wp-content/uploads/2017/09/tay-cam-game-terios-t3-linh-kien-store2.jpg', 200, '2022-01-19 04:04:26', '2022-01-13 07:04:34'),
(15, 'Tay cầm Rapoo V600S ', 'Tay cầm Rapoo V600S ', 4, 5, 'Tay cầm Rapoo V600S ', 'Tay cầm Rapoo V600S ', '2200000', 'http://img.websosanh.vn/v2/users/root_product/images/tay-cam-rapoo-v600s/bsdebkhgwphpy.jpg', 12, '2022-01-03 04:04:26', '2022-01-08 04:04:26'),
(16, 'Tay cầm chơi game có rung', 'Tay cầm chơi game có rung cho máy tính', 4, 9, 'Tay cầm chơi game có rung cho máy tính', 'Tay cầm chơi game có rung cho máy tính', '200000', 'https://giadungnhaviet.com/wp-content/uploads/2020/04/tay-cam-choi-game-cho-may-tinh-de-ban-pc-laptop-cong-usb-u706-1.jpg', 12, '2022-01-04 04:04:26', '2022-01-13 07:09:35'),
(17, 'Tay Cầm Xbox 360', 'Tay Cầm Xbox 360', 4, 7, 'Tay Cầm Xbox 360', 'Tay Cầm Xbox 360', '240000', 'https://shoptaycam.com/wp-content/uploads/2018/05/Tay-cam-xbox-360-fake-ban-thuong-co-day-tay-cam-xbox-360-controller-chinh-hang-co-day-cho-pc-ha-noi-tphcm-01.jpg', 44, '2022-01-20 04:04:26', '2022-01-31 04:04:26'),
(18, 'Tay cầm chơi game MSI Force GC30', 'Tay cầm chơi game MSI Force GC30', 4, 5, 'Tay cầm chơi game MSI Force GC30', 'Tay cầm chơi game MSI Force GC30', '2700000', 'https://anphat.com.vn/media/product/28056_msi_force_gc30_5.png', 67, '2022-01-18 04:04:26', '2022-01-31 04:04:26'),
(19, 'Tay Cầm Chơi Game Không Dây 5in1', 'Tay Cầm Chơi Game Không Dây 5in1', 4, 2, 'Tay Cầm Chơi Game Không Dây 5in1', 'Tay Cầm Chơi Game Không Dây 5in1', '2000000', 'https://salt.tikicdn.com/ts/tmp/19/da/c0/47bdb7c8f6e0946f6440bef157f56bba.jpg', 18, '2022-01-20 01:07:29', '2022-01-13 07:20:21'),
(20, 'Tay cầm xanh dương', 'Tay cầm xanh dương', 4, 2, 'Tay cầm xanh dương', 'Tay cầm xanh dương', '500000', 'https://tinhocngoisao.cdn.vccloud.vn/wp-content/uploads/2021/01/TGKD_RP_V600S_XD-300x300.jpg', 76, '2022-01-10 04:04:26', '2022-01-31 04:04:26'),
(21, 'Tay cầm chơi game Flydigi Apex 2', 'Tay cầm chơi game Flydigi Apex 2', 4, 2, 'Tay cầm chơi game Flydigi Apex 2', 'Tay cầm chơi game Flydigi Apex 2', '5000000', 'https://linhkienstore.vn/plugins/responsive_filemanager/medium/Flydigi%20Apex%202/tay-cam-choi-game-Flydigi-Apex-2%20(1)_1.jpg', 44, '2022-01-11 04:04:26', '2022-01-31 04:04:26'),
(22, 'Tay cầm chơi game DualShock 4', 'Tay cầm chơi game DualShock 4', 4, 5, 'Tay cầm chơi game DualShock 4', 'Tay cầm chơi game DualShock 4', '4500000', 'https://d1vm37nfym7tjl.cloudfront.net/web/image/product.product/16347/image_1024/%5BCUH-ZCT2G13%5D%20Tay%20c%E1%BA%A7m%20ch%C6%A1i%20game%20DualShock%204%20cho%20PS4%20%28tr%E1%BA%AFng%29?unique=e69ed50', 42, '2022-01-11 04:04:26', '2022-01-31 04:04:26'),
(23, 'Tay cầm chơi game Terios T3\r\n', 'Tay cầm chơi game Terios T3', 4, 5, 'Tay cầm chơi game Terios T3', 'Tay cầm chơi game Terios T3', '6500000', 'https://file.hstatic.net/1000263875/article/gamepad_x3_full_8ccc2ea1c9dc48cf8bafd75dd50a08a3_1024x1024.jpg', 87, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(24, 'Tay cầm PS3 đen', 'Tay cầm PS3 đen', 4, 2, 'Tay cầm PS3 đen', 'Tay cầm PS3 đen', '500000', 'https://www.nakatavn.com/sites/default/files/styles/large/public/ubercart/61nyaUEzFlL._SX466_.jpg?itok=vBNzLJRU', 19, '2022-01-13 06:55:52', '2022-01-13 07:22:52'),
(25, 'Tay Cầm Chơi Game GameSir T4W ', 'Tay Cầm Chơi Game GameSir T4W ', 4, 2, 'Tay Cầm Chơi Game GameSir T4W ', 'Tay Cầm Chơi Game GameSir T4W ', '5400000', 'https://shoptaycam.com/wp-content/uploads/2019/09/bandicam-2019-09-21-12-47-18-425_Fotor-1024x1024.jpg', 34, '2022-01-04 04:04:26', '2022-01-31 04:04:26'),
(26, 'Laptop Dell Latitude 3420', 'Laptop Dell Latitude 3420 (L3420I3SSD)', 1, 2, 'Laptop Dell Latitude 3420 (L3420I3SSD)', 'Laptop Dell Latitude 3420 (L3420I3SSD)', '30000000', 'https://hanoicomputercdn.com/media/product/59834_laptop_dell_latitude_3420_42lt342002_den_2021_6.png', 15, '2022-01-01 04:21:53', '2022-01-13 07:25:06'),
(27, 'Laptop MSI core i5', 'Laptop MSI core i5', 1, 5, 'Laptop MSI core i5', 'Laptop MSI core i5', '45000000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3Z23bw5Foaur74VwlEUDtSZ42466qmR-apA&usqp=CAU', 30, '2022-01-11 04:21:53', '2022-01-13 07:23:23'),
(28, 'Laptop MSI Modern 14 B11MO', 'Laptop MSI Modern 14 B11MO 294VN', 1, 5, 'Laptop MSI Modern 14 B11MO 294VN', 'Laptop MSI Modern 14 B11MO 294VN', '78000000', 'https://cdn.cellphones.com.vn/media/catalog/product/cache/7/thumbnail/9df78eab33525d08d6e5fb8d27136e95/l/a/laptop-msi-modern-14-b11mo-294vn-1.jpg', 54, '2022-01-12 01:03:08', '2022-01-13 07:10:27'),
(29, 'Laptop MSI Gaming Katana GF66', 'Laptop MSI Gaming Katana GF66 11UC 641VN', 1, 5, 'Laptop MSI Gaming Katana GF66 11UC 641VN', 'Laptop MSI Gaming Katana GF66 11UC 641VN', '56000000', 'https://phucanhcdn.com/media/product/44262_katana_gf66_ha1.jpg', 54, '2022-01-04 04:21:53', '2022-01-13 07:10:18'),
(30, 'Laptop MSI GF65 Thin 10UE-228VN', 'Laptop MSI GF65 Thin 10UE-228VN', 1, 5, 'Laptop MSI GF65 Thin 10UE-228VN', 'Laptop MSI GF65 Thin 10UE-228VN', '43000000', 'https://tinhocngoisao.cdn.vccloud.vn/wp-content/uploads/2021/03/LT-MSI-GF65-10UE-228VN.jpg', 41, '2022-01-12 01:03:08', '2022-01-13 07:24:37'),
(31, 'Laptop MSI GE66 Raider', 'Laptop MSI GE66 Raider 11UG 210VN', 1, 5, 'Laptop MSI GE66 Raider 11UG 210VN', 'Laptop MSI GE66 Raider 11UG 210VN', '60000000', 'https://cdn.mediamart.vn/images/product/laptop-msi-ge66-raider-11ug-210vn-GNXsEp.png', 32, '2022-01-20 01:07:29', '2022-01-13 07:11:08'),
(32, 'Laptop MSI Creator 17 B11UH', 'Laptop MSI Creator 17 B11UH', 1, 5, 'Laptop MSI Creator 17 B11UH', 'Laptop MSI Creator 17 B11UH', '70000000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0jw82cJQIw6TR54PmJvzb2SE3BYTolUJq3g&usqp=CAU', 55, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(33, 'MSI - Delta 15.6\" FHD Laptop', 'MSI - Delta 15.6\" FHD 240hz Gaming Laptop', 1, 5, 'MSI - Delta 15.6\" FHD 240hz Gaming Laptop', 'MSI - Delta 15.6\" FHD 240hz Gaming Laptop', '66000000', 'https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6468/6468118_sd.jpg', 22, '2022-01-13 01:07:29', '2022-01-13 07:10:59'),
(34, 'Laptop MSI Bravo 15 B5DD 028VN', 'Laptop MSI Bravo 15 B5DD 028VN', 1, 5, 'Laptop MSI Bravo 15 B5DD 028VN', 'Laptop MSI Bravo 15 B5DD 028VN', '66000000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsx6nxU1JSWTa51xa7oEkVGxg_z8_GlOIxAw&usqp=CAU', 50, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(35, 'Laptop MSI Core i7', 'Laptop MSI Core i7', 1, 5, 'Laptop MSI Core i7', 'Laptop MSI Core i7', '33000000', 'https://hienlaptop.com/wp-content/uploads/2020/03/thay-loa-laptop-msi-1.jpg', 44, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(36, 'MSI Pulse GL66 11UDK-255VN', 'MSI Pulse GL66 11UDK-255VN', 1, 5, 'MSI Pulse GL66 11UDK-255VN', 'MSI Pulse GL66 11UDK-255VN', '55000000', 'https://tinhocngoisao.cdn.vccloud.vn/wp-content/uploads/2021/11/msi-pulse-gl66-11udk-255vn-2.jpg', 12, '2022-01-13 04:21:53', '2022-01-29 04:21:53'),
(37, 'Laptop MSI GS66 Stealth', 'Laptop MSI GS66 Stealth 11UG 210VN', 1, 5, 'Laptop MSI GS66 Stealth 11UG 210VN', 'Laptop MSI GS66 Stealth 11UG 210VN', '80000000', 'https://cdn.mediamart.vn/images/product/laptop-msi-gs66-stealth-11ug-210vn-8H4MA8.png', 44, '2022-01-19 04:21:53', '2022-01-13 07:11:32'),
(38, 'Máy quay Sony HXR-NX200/ Pal', 'Máy quay chuyên dụng Sony HXR-NX200/ Pal', 2, 1, 'Máy quay chuyên dụng Sony HXR-NX200/ Pal', 'Máy quay chuyên dụng Sony HXR-NX200/ Pal', '50000000', 'https://binhminhdigital.com/storedata/images/product/may-quay-sony-hxrnx200.jpg', 33, '2022-01-14 02:58:53', '2022-01-13 07:11:20'),
(39, 'Máy Quay Phim Sony HDR-PJ440E', 'Máy Quay Phim Sony HDR-PJ440E', 2, 1, 'Máy Quay Phim Sony HDR-PJ440E', 'Máy Quay Phim Sony HDR-PJ440E', '57000000', '\r\nhttps://binhminhdigital.com/storedata/images/product/sony-hdrpj440e-mau-den(1).jpg', 21, '2022-01-11 04:34:40', '2022-01-31 04:34:40'),
(40, 'Máy quay phim Full HD HC', 'Máy quay phim Full HD HC-MDH3GC', 2, 2, 'Máy quay phim Full HD HC-MDH3GC', 'Máy quay phim Full HD HC-MDH3GC', '65000000', 'https://storage.googleapis.com/cdn.nhanh.vn/store1/42431/psCT/20191215/18700695/444.jpg', 11, '2022-01-12 01:03:08', '2022-01-13 07:25:06'),
(41, 'Máy quay KTS Sony Handycam 4K ', 'Máy quay KTS Sony Handycam 4K ', 2, 1, 'Máy quay KTS Sony Handycam 4K', 'Máy quay KTS Sony Handycam 4K', '100000000', 'https://phucanhcdn.com/media/product/23370_may_quay_sony_handycam_4k_fdr_axp55_64gb___black_01.jpg', 22, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(42, 'Máy quay phim Sony XDCAM', 'Máy quay phim Sony XDCAM PMW-400', 2, 1, 'Máy quay phim Sony XDCAM PMW-400', 'Máy quay phim Sony XDCAM PMW-400', '70000000', 'http://f5c.vn/upload/public/1a0535efab5171310466707df7560de2.jpg', 33, '2022-01-12 01:03:08', '2022-01-13 07:11:57'),
(43, 'Máy quay phim Sony Model SR46', 'Máy quay phim Sony Model SR46', 2, 1, 'Máy quay phim Sony Model SR46Máy quay phim Sony Model SR46', 'Máy quay phim Sony Model SR46', '60000000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRKopsATFep8_5xBoYh0rWi4_KxW64egGJKPQ&usqp=CAU', 31, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(44, 'MÁY QUAY PHIM CANON XH-A1s', 'MÁY QUAY PHIM CANON XH-A1s', 2, 2, 'MÁY QUAY PHIM CANON XH-A1s', 'MÁY QUAY PHIM CANON XH-A1s', '4000000', 'https://mayanhxachtaynhat.com/wp-content/uploads/2020/03/Canon-Xha1s-scaled.jpg', 12, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(45, 'Máy quay phim Kodak Super 8', 'Máy quay phim Kodak Super 8', 2, 2, 'Máy quay phim Kodak Super 8', 'Máy quay phim Kodak Super 8', '56000000', 'https://genk.mediacdn.vn/2018/retouch-07615-1515708222277.jpg', 46, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(46, 'Máy quay Sony Pmw Ex1r', 'Máy quay Sony Pmw Ex1r', 2, 1, 'Máy quay Sony Pmw Ex1r', 'Máy quay Sony Pmw Ex1r', '100000000', 'https://chothuelens.vn/uploads/SanPham/54/cho-thue-may-quay-phim-sony-ex1r-1.png', 18, '2022-01-12 01:07:29', '2022-01-13 07:22:52'),
(47, 'Máy Quay Phim 4K 1080P 48MP', 'Máy Quay Phim 4K 1080P 48MP', 2, 2, 'Máy Quay Phim 4K 1080P 48MP', 'Máy Quay Phim 4K 1080P 48MP', '65000000', 'https://ae01.alicdn.com/kf/HTB1_DXva7fb_uJkSmLyq6AxoXXal/Andoer-M-y-Quay-Phim-4K-1080P-48MP-WiFi-K-Thu-t-S-Quay-Video-M.jpg_Q90.jpg_.webp', 22, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(48, 'Máy quay Sony PXW-X200', 'Máy quay Sony PXW-X200', 2, 2, 'Máy quay Sony PXW-X200', 'Máy quay Sony PXW-X200', '55000000', 'https://f5c.vn/upload/public/69cb09a414306c91526304a5e122c26c.jpg', 33, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(49, 'Máy quay SONY HDR-PJ820E', 'Máy quay SONY HDR-PJ820E', 2, 1, 'Máy quay SONY HDR-PJ820E', 'Máy quay SONY HDR-PJ820E', '44000000', 'https://www.sieuthivienthong.com/imgs/art/p_9702_SONY-HDR-PJ820E.jpg', 33, '2022-01-04 04:34:40', '2022-01-31 04:34:40'),
(50, 'Smart tivi VTB 43 inch LV4387KS', 'Smart tivi VTB 43 inch LV4387KS', 3, 1, 'Smart tivi VTB 43 inch LV4387KS', 'Smart tivi VTB 43 inch LV4387KS', '20000000', 'https://dienmaythienhoa.vn/static/images/4.%20hinh%20sp/3.%20Hinh%20SP%202/smart-tivi-VTB-43-inch-LV4387KS-1.jpg', 11, '2021-12-27 01:26:40', '2022-01-14 00:55:26'),
(51, 'Smart Tivi FFalcon 40 inch 40SF1', 'Smart Tivi FFalcon 40 inch 40SF1', 3, 2, 'Smart Tivi FFalcon 40 inch 40SF1', 'Smart Tivi FFalcon 40 inch 40SF1', '23000000', 'https://cdn.tgdd.vn/Products/Images/1942/219650/ffalcon-40sf1-9-550x340.jpg', 11, '2022-01-11 07:49:06', '2022-01-31 04:48:08'),
(52, 'Smart Tivi Samsung 4K 82 inch', 'Smart Tivi Samsung 4K 82 inch UA82TU8100', 3, 2, 'Smart Tivi Samsung 4K 82 inch UA82TU8100', 'Smart Tivi Samsung 4K 82 inch UA82TU8100', '22000000', 'https://hc.com.vn/i/ecommerce/media/AV.001720_FEATURE_67610.png', 66, '2022-01-12 01:03:08', '2022-01-13 07:12:11'),
(53, 'Smart Tivi Casper Full HD', 'Smart Tivi Casper Full HD', 3, 1, 'Smart Tivi Casper Full HD', 'Smart Tivi Casper Full HD', '11000000', 'https://thegioidienmayonline.com/wp-content/uploads/2021/05/smart-tivi-casper-42-inch-42fx5200.jpg', 5, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(54, 'Smart Tivi Samsung 43 inch', 'Smart Tivi Samsung 43 inch', 3, 2, 'Smart Tivi Samsung 43 inch', 'Smart Tivi Samsung 43 inch', '33000000', 'https://cdn.tgdd.vn/Products/Images/1942/219401/samsung-ua43t6500-245020-105055-550x340.jpg', 12, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(55, 'Smart Tivi Samsung 32 inch 32T4300', 'Smart Tivi Samsung 32 inch 32T4300', 3, 2, 'Smart Tivi Samsung 32 inch 32T4300', 'Smart Tivi Samsung 32 inch 32T4300', '24000000', 'https://hc.com.vn/i/ecommerce/media/AV.001050_FEATURE_58572.jpg', 33, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(56, 'Tivi Sharp 42 Inch 2T-C42BG1X ', 'Tivi Sharp 42 Inch 2T-C42BG1X ', 3, 2, 'Tivi Sharp 42 Inch 2T-C42BG1X ', 'Tivi Sharp 42 Inch 2T-C42BG1X ', '14000000', 'https://cdn.nguyenkimmall.com/images/detailed/634/10045117-android-tivi-sharp-4k-42-inch-2t-c42bg1x-1_qo56-gr.jpg', 9, '2022-01-13 01:07:29', '2022-01-13 07:20:21'),
(57, 'Tivi Vsmart', 'Tivi Vsmart', 3, 2, 'Tivi Vsmart', 'Tivi Vsmart', '12000000', 'https://cdn-www.vinid.net/2020/08/0573a01c-nh-gi%C3%A1-tivi-vsmart.jpg', 12, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(58, 'Tivi Sony Bravia KDL-50W660G', 'Tivi Sony Bravia KDL-50W660G', 3, 1, 'Tivi Sony Bravia KDL-50W660G', 'Tivi Sony Bravia KDL-50W660G', '24000000', 'https://sbay.com.vn/upload/product/0916256256/sony-kdl-50w660g-244420-034444-550x340jpg.jpg', 22, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(59, 'Tivi Samsung UA50TU8500', 'Tivi Samsung UA50TU8500', 3, 2, 'Tivi Samsung UA50TU8500', 'Tivi Samsung UA50TU8500', '13000000', 'https://dienmaygiare.net/wp-content/uploads/2020/03/tivi-samsung-ua50tu8500.jpg', 21, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(60, 'Smart Tivi Casper 32 inch 32HX6200', 'Smart Tivi Casper 32 inch 32HX6200', 3, 2, 'Smart Tivi Casper 32 inch 32HX6200', 'Smart Tivi Casper 32 inch 32HX6200', '30000000', 'https://cdn.tgdd.vn/Products/Images/1942/232170/casper-32hx6200-081020-031033.jpg', 12, '2022-01-04 01:07:29', '2022-01-13 07:25:06'),
(61, 'Tivi Sony Smart Tivi LG 4K ', 'Tivi Sony Smart Tivi LG 4K ', 3, 1, 'Tivi Sony Smart Tivi LG 4K ', 'Tivi Sony Smart Tivi LG 4K ', '22000000', 'https://tivirenhat.net/files/sanpham/50/1/jpg/smart-tivi-lg-4k-43-inch-43um7600pta.jpg', 22, '2022-01-13 04:48:08', '2022-01-31 04:48:08'),
(62, 'Chuột máy tính DARE-U EM908', 'Chuột máy tính DARE-U EM908', 6, 10, 'Chuột máy tính DARE-U EM908', 'Chuột máy tính DARE-U EM908', '200000', 'https://www.dinhvangcomputer.vn/wp-content/uploads/2020/12/Chuot-may-tinh-DARE-U-EM908_TM205U08601G-1.jpg', 33, '2021-12-27 01:26:40', '2022-01-15 02:58:53'),
(63, 'Chuột máy tính Fuhlen G70 Gaming', 'Chuột máy tính Fuhlen G70 Gaming', 6, 7, 'Chuột máy tính Fuhlen G70 Gaming', 'Chuột máy tính Fuhlen G70 Gaming', '340000', 'https://anphat.com.vn/media/product/17457_mouse_fuhlen_g70_optical_usb___gaming.jpg', 12, '2022-01-11 07:49:06', '2022-01-31 08:00:20'),
(64, 'Chuột máy tính MARVO M910', 'Chuột máy tính MARVO M910', 6, 7, 'Chuột máy tính MARVO M910', 'Chuột máy tính MARVO M910', '540000', 'https://catthanh.com/1_html/img/product/thum/1445263856_chuot-may-tinh.jpg', 8, '2022-01-12 01:03:08', '2022-01-13 07:23:23'),
(65, 'Logitech Chuột Máy tính G102', 'Logitech Chuột Máy tính G102 8000DPI RGB', 6, 7, 'Logitech Chuột Máy tính G102 8000DPI RGB', 'Logitech Chuột Máy tính G102 8000DPI RGB', '1000000', 'https://product.hstatic.net/1000379362/product/chuot_logitech_2_2ce23484871d443caaaf9aae01d75cd4.jpg', 22, '2022-01-12 01:03:08', '2022-01-13 07:03:48'),
(66, 'Chuột máy tính OP20 PF168', 'Chuột máy tính OP20 PF168', 6, 7, 'Chuột máy tính OP20 PF168', 'Chuột máy tính OP20 PF168', '1000000', 'https://media3.scdn.vn/img3/2019/5_1/chuot-may-tinh-sunwolf-op20-gaming-mouse-pf168-1m4G3-heFCEp_simg_d0daf0_800x1200_max.png', 22, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(67, 'Chuột không dây Kute Fuhlen A05G', 'Chuột không dây Kute Fuhlen A05G', 6, 7, 'Chuột không dây Kute Fuhlen A05G', 'Chuột không dây Kute Fuhlen A05G', '500000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE4BD6J3LRv-nesBGhKoZfGw6ZJDNXWBNBmA&usqp=CAU', 22, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(68, 'Chuột máy tính MARVO M910', 'Chuột máy tính MARVO M910', 6, 7, 'Chuột máy tính MARVO M910', 'Chuột máy tính MARVO M910', '200000', 'https://catthanh.com/1_html/img/product/thum/1445263856_chuot-may-tinh.jpg', 32, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(69, 'Chuột máy tính Newmen E500', 'Chuột máy tính Newmen E500', 6, 7, 'Chuột máy tính Newmen E500', 'Chuột máy tính Newmen E500', '200000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7YrfrxXX3qXElz7gw0RRX_XzhAQAG_SuqDA&usqp=CAU', 22, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(70, 'Chuột Máy Tính Gaming Mouse Pf21', 'Chuột Máy Tính Gaming Mouse Pf21', 6, 7, 'Chuột Máy Tính Gaming Mouse Pf21', 'Chuột Máy Tính Gaming Mouse Pf21', '650000', 'https://hazomi.com/wp-content/uploads/2020/03/04f1dd2b7023bc312397c2f915c4a0e2.jpg', 23, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(71, 'Chuột Máy Tính Quang', 'Chuột Máy Tính Quang', 6, 7, 'Chuột Máy Tính Quang', 'Chuột Máy Tính Quang', '2000000', 'https://sg-test-11.slatic.net/p/fcb13fb80a47acf87f7c4a0fdc32e89d.jpg_320x320.jpg', 32, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(72, 'Chuột máy tính MARVO M-300', 'Chuột máy tính MARVO M-300', 6, 7, 'Chuột máy tính MARVO M-300', 'Chuột máy tính MARVO M-300', '2000000', 'https://catthanh.com/1_html/img/product_img/thum/1445173615_chuot-may-tinh.jpg', 23, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(73, 'Chuột máy tính Genius NX7005', 'Chuột máy tính Genius NX7005', 6, 7, 'Chuột máy tính Genius NX7005', 'Chuột máy tính Genius NX7005', '1000000', 'https://bizweb.dktcdn.net/100/027/544/products/chuot-may-tinh-genius-nx7005-xanh.jpg?v=1516328685240', 23, '2022-01-04 05:03:18', '2022-01-31 05:03:18'),
(74, 'Quạt tản nhiệt 8cm 12VDC', 'Quạt tản nhiệt 8cm 12VDC', 7, 7, 'Quạt tản nhiệt 8cm 12VDC', 'Quạt tản nhiệt 8cm 12VDC', '30000', 'https://nshopvn.com/wp-content/uploads/2019/03/quat-tan-nhiet-8cm-12vdc-d8gi-3-1024x1024.jpg', 23, '2021-12-27 01:26:40', '2022-01-14 00:55:26'),
(75, 'QUẠT TẢN NHIỆT 120MM', 'QUẠT TẢN NHIỆT 120MM', 7, 7, 'QUẠT TẢN NHIỆT 120MM', 'QUẠT TẢN NHIỆT 120MM', '500000', 'https://hagico.net/wp-content/uploads/2017/11/S-FLEX-120-SSF21D-quat-hagico.jpg', 23, '2022-01-11 07:49:06', '2022-01-31 08:00:20'),
(76, 'Quạt tản nhiệt Nidec 24V', 'Quạt tản nhiệt Nidec 24V', 7, 7, 'Quạt tản nhiệt Nidec 24V', 'Quạt tản nhiệt Nidec 24V', '75000', 'https://quattannhiet.com/wp-content/uploads/2017/05/quat-tan-nhiet-nidec-24v-50x50x10.jpg', 55, '2022-01-12 01:03:08', '2022-01-21 01:03:08'),
(77, 'QUẠT TẢN NHIỆT 12VDC', 'QUẠT TẢN NHIỆT 12VDC', 7, 7, 'QUẠT TẢN NHIỆT 12VDC', 'QUẠT TẢN NHIỆT 12VDC', '25000', 'https://cf.shopee.vn/file/c3a1e4c2661ab19f9e0e0322886f941a', 66, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(78, 'Quạt tản nhiệt 33 bóng đèn', 'Quạt tản nhiệt 33 bóng đèn', 7, 7, 'Quạt tản nhiệt 33 bóng đèn', 'Quạt tản nhiệt 33 bóng đèn', '76000', 'https://salt.tikicdn.com/cache/400x400/ts/product/8a/d0/04/2eebb301affe1910512538ab1b24aede.jpg', 23, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(79, 'Quạt Tản Nhiệt 24VDC', 'Quạt Tản Nhiệt 24VDC', 7, 7, 'Quạt Tản Nhiệt 24VDC', 'Quạt Tản Nhiệt 24VDC', '76000', 'https://bizweb.dktcdn.net/thumb/1024x1024/100/228/168/products/quat-tan-nhiet-6x6x2-5.jpg?v=1548670709430', 65, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(80, 'Quạt Tản Nhiệt ID-Cooling ', 'Quạt Tản Nhiệt ID-Cooling ', 7, 7, 'Quạt Tản Nhiệt ID-Cooling ', 'Quạt Tản Nhiệt ID-Cooling ', '87000', 'https://maytinhhd.com/wp-content/uploads/2020/10/maytinhhungdanh-ZF-12025P-Yel-2.jpg', 77, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(81, 'Quạt tản nhiệt 220V 12x12cm', 'Quạt tản nhiệt 220V 12x12cm', 7, 7, 'Quạt tản nhiệt 220V 12x12cm', 'Quạt tản nhiệt 220V 12x12cm', '87000', 'https://kholinhkien.com.vn/wp-content/uploads/2016/12/quat-tan-nhiet-220v-12x12cm.jpg', 54, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(82, 'Quạt Tản Nhiệt Mini', 'Quạt Tản Nhiệt Mini', 7, 7, 'Quạt Tản Nhiệt Mini', 'Quạt Tản Nhiệt Mini', '88000', 'https://bizweb.dktcdn.net/thumb/1024x1024/100/228/168/products/quat-tan-nhiet-4x4x1-8.jpg?v=1526271503193', 78, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(83, 'Quạt Tản Nhiệt Brushless', 'Quạt Tản Nhiệt Brushless', 7, 7, 'Quạt Tản Nhiệt Brushless', 'Quạt Tản Nhiệt Brushless', '90000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9bCJu1ygxUoZTsdNntqKbHUNf_uG9Fe1F6w&usqp=CAU', 88, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(84, 'Quạt tản nhiệt modem wifi ', 'Quạt tản nhiệt modem wifi ', 7, 7, 'Quạt tản nhiệt modem wifi ', 'Quạt tản nhiệt modem wifi ', '90000', 'https://maybommini.com/wp-content/uploads/2018/06/quat-tan-nhiet-lam-mat-cho-modem-wifi.jpg', 88, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(85, 'Quạt tản nhiệt 220v', 'Quạt tản nhiệt 220v', 7, 7, 'Quạt tản nhiệt 220v', 'Quạt tản nhiệt 220v', '90000', 'https://quattannhiet.com/wp-content/uploads/2017/05/quat-tan-nhiet-170-150-50-220v-300x300.jpg', 78, '2022-01-03 05:14:11', '2022-01-31 05:14:11'),
(86, 'Router wifi ASUS RT-AX3000', 'Router wifi ASUS RT-AX3000', 8, 7, 'Router wifi ASUS RT-AX3000', 'Router wifi ASUS RT-AX3000', '3500000', 'https://hanoicomputercdn.com/media/product/51865_rt_ax3000_02b.png', 32, '2021-12-27 01:26:40', '2022-01-15 02:58:53'),
(87, 'Bộ phát wifi TP-Link WR841N', 'Bộ phát wifi TP-Link WR841N', 8, 7, 'Bộ phát wifi TP-Link WR841N', 'Bộ phát wifi TP-Link WR841N', '3400000', 'https://hanoicomputercdn.com/media/product/2070_router_wifi_tp_link_wr841n_wireless.jpg', 55, '2022-01-11 07:49:06', '2022-01-19 08:00:20'),
(88, 'Bộ phát Wifi Asus RT - AX55', 'Bộ phát Wifi Asus RT - AX55', 8, 7, 'Bộ phát Wifi Asus RT - AX55', 'Bộ phát Wifi Asus RT - AX55', '7600000', 'https://binhminhdigital.com/StoreData/images/Product/ThietBiMang-Maytinh-game/bo-phat-wifi-asus-rt-ax55.jpg', 33, '2022-01-12 01:03:08', '2022-01-21 01:03:08'),
(89, 'Bộ phát Wifi Asus RT-AC1200', 'Bộ phát Wifi Asus RT-AC1200', 8, 7, 'Bộ phát Wifi Asus RT-AC1200', 'Bộ phát Wifi Asus RT-AC1200', '1100000', 'https://binhminhdigital.com/storedata/images/product/router-wifi-asus-rt-ac1200-v2(1).jpg', 33, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(90, 'Bộ phát wifi Router Wifi Sony', 'Bộ phát wifi Router Wifi Sony', 8, 1, 'Bộ phát wifi Router Wifi Sony', 'Bộ phát wifi Router Wifi Sony', '540000', 'https://salt.tikicdn.com/ts/product/ab/f9/31/ccd212fb532d2bfde4a7d6b848a89de4.png', 118, '2022-01-12 01:03:08', '2022-01-13 07:24:37'),
(91, 'ROUTER LTE CP903', 'ROUTER LTE CP903', 8, 7, 'ROUTER LTE CP903', 'ROUTER LTE CP903', '1500000', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZ_WDQUCsArszimypkVLzDtMONIGvDgLhBSA&usqp=CAU', 55, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(92, 'Router Wifi Chuẩn AC1200', 'Router Wifi Chuẩn AC1200', 8, 7, 'Router Wifi Chuẩn AC1200', 'Router Wifi Chuẩn AC1200', '760000', 'https://cdn.tgdd.vn/Products/Images/4727/224347/router-wifi-chuan-ac1200-tenda-ac7-den-1-600x600.jpg', 33, '2022-01-13 01:07:29', '2022-01-31 05:37:05'),
(93, 'Bộ phát wifi Router AX6000', 'Bộ phát wifi Router AX6000', 8, 7, 'Bộ phát wifi Router AX6000', 'Bộ phát wifi Router AX6000', '870000', 'https://cf.shopee.vn/file/6e068182e522684ad39ab2dce9bcf40b_tn', 66, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(94, 'Bộ Phát Wifi 4G LTE CPE', 'Bộ Phát Wifi 4G LTE CPE', 8, 7, 'Bộ Phát Wifi 4G LTE CPE', 'Bộ Phát Wifi 4G LTE CPE', '870000', 'https://ae01.alicdn.com/kf/H8bc6e86ca719477dabafe8dd2352c9031/M-Kh-a-300Mbps-Router-B-Ph-t-Wifi-4G-LTE-CPE-Tuy-n-Di-ng.jpg_Q90.jpg_.webp', 12, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(95, 'Bộ phát Wifi Router 4C', 'Bộ phát Wifi Router 4C', 8, 7, 'Bộ phát Wifi Router 4C', 'Bộ phát Wifi Router 4C', '900000', 'https://thuonggiado.vn/uploads/product/2017/TnF9-bo-phat-wifi-xiaomi-router-4c.jpg', 222, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(96, 'Bộ Phát Wifi CPE B525', 'Bộ Phát Wifi CPE B525', 8, 7, 'Bộ Phát Wifi CPE B525', 'Bộ Phát Wifi CPE B525', '220000', 'https://phatwifi4g.com/data/admin/images/thread/602e371fa44d5.jpg', 23, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(97, 'Bộ Phát Wifi 4A Gigabit', 'Bộ Phát Wifi 4A Gigabit', 8, 7, 'Bộ Phát Wifi 4A Gigabit', 'Bộ Phát Wifi 4A Gigabit', '900000', 'https://bizweb.dktcdn.net/thumb/1024x1024/100/314/518/products/wifi-router-xiaomi-4a-gigabit-13.jpg?v=1576564329303', 32, '2022-01-03 05:37:05', '2022-01-31 05:37:05'),
(98, 'Lót chuột Gaming Brand', 'Lót chuột Gaming Brand', 9, 5, 'Lót chuột Gaming Brand', 'Lót chuột Gaming Brand', '2000000', 'https://kayan.vn/images/thumbs/0004283_lot-chuot-co-lon-gaming-brand-msi-mau-1_550.jpeg', 77, '2021-12-27 01:26:40', '2022-01-15 02:58:53'),
(99, 'Miếng lót chuột Agility', 'Miếng lót chuột Agility', 9, 5, 'Miếng lót chuột Agility', 'Miếng lót chuột Agility', '870000', 'https://kayan.vn/images/thumbs/0004283_lot-chuot-co-lon-gaming-brand-msi-mau-1_550.jpeg', 89, '2022-01-11 07:49:06', '2022-01-11 08:00:20'),
(100, 'Miếng lót chuột Agility GD70', 'Miếng lót chuột Agility GD70', 9, 5, 'Miếng lót chuột Agility GD70', 'Miếng lót chuột Agility GD70', '800000', 'https://salt.tikicdn.com/ts/product/9e/dd/65/8737c561d07ac61a3fb399548df3b4c1.png', 55, '2022-01-12 01:03:08', '2022-01-21 01:03:08'),
(101, 'Lót Chuột MSI 0,2x21x26', 'Lót Chuột MSI 0,2x21x26', 9, 5, 'Lót Chuột MSI 0,2x21x26', 'Lót Chuột MSI 0,2x21x26', '900000', 'https://bizweb.dktcdn.net/thumb/1024x1024/100/270/727/products/lot-chuot-msi-21x26.jpg?v=1614481202560', 32, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(102, 'Lót chuột MSI 3 (90x40)', 'Lót chuột MSI 3 (90x40)', 9, 5, 'Lót chuột MSI 3 (90x40)', 'Lót chuột MSI 3 (90x40)', '200000', 'https://lh3.googleusercontent.com/OC0BprgeH4hFiRe0kA8BNzGTx8Bd78iQJiUHV1926ljhofWmIJMkDw6uCJveQzGT-dOi9Phy709O0fsP7RCH0O1HHQ-DeJHA1vARYvacw0xTV13rpcvJWnlqF54F4UtdRaQgp7WQXt4=w1000-h750-no', 33, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(103, 'Lót chuột RGB Gaming MSI ', 'Lót chuột RGB Gaming MSI ', 9, 5, 'Lót chuột RGB Gaming MSI ', 'Lót chuột RGB Gaming MSI ', '2500000', 'https://salt.tikicdn.com/cache/525x525/ts/product/e0/00/7f/2f6708cca4efd8172f4341cd507a6017.jpg', 22, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(104, 'Lót chuột MSI Big Size', 'Lót chuột MSI Big Size', 9, 5, 'Lót chuột MSI Big Size', 'Lót chuột MSI Big Size', '980000', 'https://bizweb.dktcdn.net/100/270/727/files/lot-chuot-msi-big-size.jpg?v=1614481144803', 32, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(105, 'Miếng lót chuột Agility GD700', 'Miếng lót chuột Agility GD700', 9, 5, 'Miếng lót chuột Agility GD700', 'Miếng lót chuột Agility GD700', '2000000', 'https://salt.tikicdn.com/cache/200x200/ts/product/f2/89/2f/0c830dfdd47eb9e7c297a06ea653a650.jpg', 23, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(106, 'Miếng lót chuột Zadez', 'Miếng lót chuột Zadez', 9, 5, 'Miếng lót chuột Zadez', 'Miếng lót chuột Zadez', '1200000', 'https://fptshop.com.vn/Uploads/images/2015/Tin-Tuc/BaoPK/A7(2016)/Lot-chuot-zadez-gp-850w-2.JPG', 99, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(107, 'Miếng lót chuột MSI CD-200', 'Miếng lót chuột MSI CD-200', 9, 5, 'Miếng lót chuột MSI CD-200', 'Miếng lót chuột MSI CD-200', '800000', 'https://salt.tikicdn.com/ts/product/bc/aa/1e/696d5619fc58046cadd6fa0a2943cd69.png', 321, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(108, 'Miếng Lót Chuột Jujutsu Kaisen', 'Miếng Lót Chuột Jujutsu Kaisen', 9, 5, 'Miếng Lót Chuột Jujutsu Kaisen', 'Miếng Lót Chuột Jujutsu Kaisen', '3000000', 'https://my-test-11.slatic.net/p/d2138cb8de470042fb49533d9ea8084b.jpg_320x320.jpg', 23, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(109, 'Lót Chuột Game Thủ Mousepad', 'Lót Chuột Game Thủ Mousepad', 9, 7, 'Lót Chuột Game Thủ Mousepad', 'Lót Chuột Game Thủ Mousepad', '820000', 'http://ae01.alicdn.com/kf/Ha8650bd247034827831da3811fa62536h/Mi-ng-L-t-Chu-t-Ch-i-Game-L-n-Mi-ng-L-t-Chu.jpg_Q90.jpg_.webp', 80, '2022-01-10 05:46:42', '2022-01-31 05:46:42'),
(110, 'Card đồ họa ADM', 'Card đồ họa ADM', 10, 7, 'Card đồ họa ADM', 'Card đồ họa ADM', '30000000', 'https://fptshop.com.vn/uploads/originals/2015/7/9//635720774503909671_card_do_hoa_ADM_va_man_hinh_4k%20(1).jpg', 99, '2021-12-27 01:26:40', '2022-01-15 02:58:53'),
(111, 'Card đồ họa GTX1650', 'Card đồ họa GTX1650', 10, 7, 'Card đồ họa GTX1650', 'Card đồ họa GTX1650', '10000000', 'http://maytinhvietphong.vn/media/news/353_top_card_do_hoa_gtx1650_gia_re_nhat.png', 33, '2022-01-11 07:49:06', '2022-01-31 08:00:20'),
(112, 'MSI RTX 3070 SUPRIM', 'MSI RTX 3070 SUPRIM', 10, 5, 'MSI RTX 3070 SUPRIM', 'MSI RTX 3070 SUPRIM', '20000000', 'https://xuepc.vn/wp-content/uploads/2021/01/vga-msi-suprim-rtx3070-8G_2.jpg', 22, '2022-01-12 01:03:08', '2022-01-21 01:03:08'),
(113, 'MSI RTX 3070 8G', 'MSI RTX 3070 8G', 10, 5, 'MSI RTX 3070 8G', 'MSI RTX 3070 8G', '15000000', 'https://m.maihoang.com.vn/thumb/crop/12003', 32, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(114, 'MSI STRIX RTX', 'MSI STRIX RTX', 10, 5, 'MSI STRIX RTX', 'MSI STRIX RTX', '21000000', 'https://product.hstatic.net/200000061442/product/asus-rog-strix-rtx-3070-gaming-8gb-gddr6-2_9187f2ae75154e4bba692cac651491da_master.jpg', 65, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(115, 'MSI GeForce RTX 3070', 'MSI GeForce RTX 3070', 10, 5, 'MSI GeForce RTX 3070', 'MSI GeForce RTX 3070', '31000000', 'https://datatronic.fi/535980-large_default/msi-geforce-rtx-3070-ti-suprim-x-8g-nvidia-8-gb-gddr6x-msi-geforce-rtx-3070-ti-suprim-x-8g.jpg', 55, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(116, 'ASUS KO GeForce RTX™', 'ASUS KO GeForce RTX™', 10, 7, 'ASUS KO GeForce RTX™', 'ASUS KO GeForce RTX™', '14000000', 'https://anphat.com.vn/media/product/35506_ko_rtx3070_o8g_01.jpg', 22, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(117, 'GRAPHIC CARD(การ์ดจอ)', 'GRAPHIC CARD(การ์ดจอ)', 10, 7, 'GRAPHIC CARD(การ์ดจอ)', 'GRAPHIC CARD(การ์ดจอ)', '10000000', 'https://th-live-05.slatic.net/p/2753b664508ff39c6cf9f058965b5bc4.png_720x720q80.jpg_.webp', 23, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(118, 'GIGABYTE RTX 3060 GAMING', 'GIGABYTE RTX 3060 GAMING', 10, 7, 'GIGABYTE RTX 3060 GAMING', 'GIGABYTE RTX 3060 GAMING', '5000000', 'https://th-live-05.slatic.net/p/da98e3fe8f00303a67649ec4d8e7277f.png_720x720q80.jpg_.webp', 33, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(119, 'Gigabyte rtx 2060', 'Gigabyte rtx 2060', 10, 7, 'Gigabyte rtx 2060', 'Gigabyte rtx 2060', '12000000', 'https://th-test-11.slatic.net/p/6c8c711cdcef7c06d356d5280aefb8f5.jpg', 66, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(120, 'Gigabyte GeForce RTX 3060', 'Gigabyte GeForce RTX 3060', 10, 7, 'Gigabyte GeForce RTX 3060', 'Gigabyte GeForce RTX 3060', '5400000', 'https://www.shoppingexpress.com.au/assets/full/GV-N3060EAGLE-OC-12GD-V2.jpg', 23, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(121, 'Card đồ họa VGA Inno3D', 'Card đồ họa VGA Inno3D', 10, 7, 'Card đồ họa VGA Inno3D', 'Card đồ họa VGA Inno3D', '8000000', 'https://laptop88.vn/media/product/6463_photo_2021_05_27_09_14_49.jpg', 21, '2022-01-05 06:02:13', '2022-01-04 06:02:13'),
(122, 'Bàn phím Fuhlen L411 USB', 'Bàn phím Fuhlen L411 USB', 11, 7, 'Bàn phím Fuhlen L411 USB', 'Bàn phím Fuhlen L411 USB', '500000', 'https://www.phucanh.vn/media/lib/16804_BanphimFuhlenL411USB-2.jpg', 44, '2021-12-27 01:26:40', '2022-01-14 00:55:26'),
(123, 'Bàn phím Alienware AW568', 'Bàn phím Alienware AW568', 11, 7, 'Bàn phím Alienware AW568', 'Bàn phím Alienware AW568', '900000', 'https://anphat.com.vn/media/product/28074_alienware_aw568.jpg', 56, '2022-01-11 07:49:06', '2022-01-13 07:25:06'),
(124, 'Bàn Phím Cơ Razer Huntsman', 'Bàn Phím Cơ Razer Huntsman', 11, 7, 'Bàn Phím Cơ Razer Huntsman', 'Bàn Phím Cơ Razer Huntsman', '1000000', 'https://cdn.tgdd.vn/Products/Images/4547/243200/co-co-day-gaming-razer-huntsman-tournament-edition-2-org.jpg', 65, '2022-01-12 01:03:08', '2022-01-21 01:03:08'),
(125, 'Bàn Phím Gaming K63', 'Bàn Phím Gaming K63', 11, 7, 'Bàn Phím Gaming K63', 'Bàn Phím Gaming K63', '800000', 'https://cdn.tgdd.vn/Products/Images/4547/230870/ban-phim-co-co-day-gaming-corsair-k63-den-1-1-org.jpg', 78, '2022-01-12 01:03:08', '2022-01-29 01:03:08'),
(126, 'Bàn phím AKKO 3108', 'Bàn phím AKKO 3108', 11, 7, 'Bàn phím AKKO 3108', 'Bàn phím AKKO 3108', '2000000', 'https://product.hstatic.net/1000026716/product/gearvn-ban-phim-akko-3108-v2-bilibili-akko-switch-3666_5922f6780bde4b97be414a81a7da4ef4.jpg', 78, '2022-01-12 01:03:08', '2022-01-15 01:03:08'),
(127, 'Bàn phím Magic Keyboard US', 'Bàn phím Magic Keyboard US', 11, 10, 'Bàn phím Magic Keyboard US', 'Bàn phím Magic Keyboard US', '2500000', 'https://cdn.tgdd.vn/Products/Images/1882/237528/ban-phim-magic-keyboard-us-apple-mla22-1-org.jpg', 44, '2022-01-20 01:07:29', '2022-01-29 01:07:29'),
(128, 'Bàn phím vi tính Prolink', 'Bàn phím vi tính Prolink', 11, 7, 'Bàn phím vi tính Prolink', 'Bàn phím vi tính Prolink', '800000', 'https://cdn.nguyenkimmall.com/images/detailed/503/10037725-ban-phim-vi-tinh-prolink-pkcs-1005-1.jpg', 88, '2022-01-13 01:07:29', '2022-01-28 01:07:29'),
(129, 'Bàn phim cơ DareU EK1280', 'Bàn phim cơ DareU EK1280', 11, 7, 'Bàn phim cơ DareU EK1280', 'Bàn phim cơ DareU EK1280', '550000', 'https://www.playzone.vn/image/catalog/san%20pham/dare-u/ban-phim/EK1280/1.png', 44, '2022-01-13 01:07:29', '2022-01-31 01:07:29'),
(130, 'Bàn phím cơ IKBC CD108', 'Bàn phím cơ IKBC CD108', 11, 7, 'Bàn phím cơ IKBC CD108', 'Bàn phím cơ IKBC CD108', '780000', 'https://www.playzone.vn/image/catalog/san%20pham/IKBC/cd108/1.jpg', 65, '2022-01-12 01:07:29', '2022-01-27 01:07:29'),
(131, 'Bàn phím cơ E-DRA EK3104', 'Bàn phím cơ E-DRA EK3104', 11, 7, 'Bàn phím cơ E-DRA EK3104', 'Bàn phím cơ E-DRA EK3104', '657000', 'https://anphat.com.vn/media/product/29936_e_dra_ek3014__1_.png', 65, '2022-01-20 01:07:29', '2022-01-31 01:07:29'),
(132, 'Bàn Phím Langtu-LK106', 'Bàn Phím Langtu-LK106', 11, 7, 'Bàn Phím Langtu-LK106', 'Bàn Phím Langtu-LK106', '1100000', 'https://nguyencongpc.vn/media/product/2909-ban-phim-langtu-lk106-cong-usb-chinh-hang.jpg', 54, '2022-01-04 01:07:29', '2022-01-31 01:07:29'),
(133, 'BÀN PHÍM CƠ BJX KM9', 'BÀN PHÍM CƠ BJX KM9', 11, 7, 'BÀN PHÍM CƠ BJX KM9', 'BÀN PHÍM CƠ BJX KM9', '2200000', 'https://thuyminh.vn/wp-content/uploads/2020/05/KM9-2-2.png', 123, '2022-01-12 06:40:03', '2022-01-31 06:40:03');

--
-- Triggers `tbl_product`
--
DELIMITER $$
CREATE TRIGGER `Update_tblp` BEFORE UPDATE ON `tbl_product` FOR EACH ROW BEGIN
if(NEW.product_status < 0) THEN
    SIGNAL sqlstate '45001' set message_text = "Số lượng đặt vượt quá số lượng hiện có";
END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_voucher`
--

CREATE TABLE `tbl_voucher` (
  `voucher_id` int(11) NOT NULL,
  `voucher_code` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `voucher_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `voucher_quantity` int(11) NOT NULL,
  `voucher_date` date NOT NULL,
  `voucher_sale` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_voucher`
--

INSERT INTO `tbl_voucher` (`voucher_id`, `voucher_code`, `voucher_name`, `voucher_quantity`, `voucher_date`, `voucher_sale`) VALUES
(1, 'VC001', 'Giảm 10% tổng trị giá hóa đơn', 10, '2022-01-31', 10),
(2, 'VC002', 'Giảm 12% tổng trị giá hóa đơn', 5, '2022-01-20', 12),
(3, 'VC003', 'Giảm 20% tổng trị giá đơn hàng', 6, '2022-01-04', 20),
(4, 'VC004', 'Giảm 5% tổng trị giá đơn hàng', 12, '2022-01-07', 5),
(5, 'VC005', 'Giảm 50% tổng trị giá đơn hàng', 3, '2022-01-31', 50),
(6, 'VC006', 'Giảm 12% tổng trị giá đơn hàng', 34, '2022-01-17', 12),
(7, 'VC007', 'Giảm 8% tổng trị giá đơn hàng', 100, '2022-01-31', 8),
(8, 'VC008', 'Giảm 24% tổng trị giá đơn hàng', 32, '2022-01-27', 24),
(9, 'VC009', 'Giảm 65% tổng trị giá đơn hàng', 2, '2022-01-31', 65),
(10, 'VC010', 'Giảm 100% tổng trị giá đơn hàng', 1, '2022-01-31', 100);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`cart_id`),
  ADD KEY `fk_customer_cart` (`customer_id`),
  ADD KEY `fk_product_cart` (`product_id`);

--
-- Indexes for table `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`admin_id`);

--
-- Indexes for table `tbl_brand`
--
ALTER TABLE `tbl_brand`
  ADD PRIMARY KEY (`brand_id`);

--
-- Indexes for table `tbl_category_product`
--
ALTER TABLE `tbl_category_product`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `tbl_customers`
--
ALTER TABLE `tbl_customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Indexes for table `tbl_order`
--
ALTER TABLE `tbl_order`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `FK_order_voucher` (`voucher_id`);

--
-- Indexes for table `tbl_order_details`
--
ALTER TABLE `tbl_order_details`
  ADD PRIMARY KEY (`order_details_id`);

--
-- Indexes for table `tbl_product`
--
ALTER TABLE `tbl_product`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `tbl_voucher`
--
ALTER TABLE `tbl_voucher`
  ADD PRIMARY KEY (`voucher_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `cart_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `admin_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_brand`
--
ALTER TABLE `tbl_brand`
  MODIFY `brand_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `tbl_category_product`
--
ALTER TABLE `tbl_category_product`
  MODIFY `category_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `tbl_customers`
--
ALTER TABLE `tbl_customers`
  MODIFY `customer_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_order`
--
ALTER TABLE `tbl_order`
  MODIFY `order_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tbl_order_details`
--
ALTER TABLE `tbl_order_details`
  MODIFY `order_details_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `tbl_product`
--
ALTER TABLE `tbl_product`
  MODIFY `product_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=134;

--
-- AUTO_INCREMENT for table `tbl_voucher`
--
ALTER TABLE `tbl_voucher`
  MODIFY `voucher_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `fk_customer_cart` FOREIGN KEY (`customer_id`) REFERENCES `tbl_customers` (`customer_id`),
  ADD CONSTRAINT `fk_product_cart` FOREIGN KEY (`product_id`) REFERENCES `tbl_product` (`product_id`);

--
-- Constraints for table `tbl_order`
--
ALTER TABLE `tbl_order`
  ADD CONSTRAINT `FK_order_voucher` FOREIGN KEY (`voucher_id`) REFERENCES `tbl_voucher` (`voucher_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
