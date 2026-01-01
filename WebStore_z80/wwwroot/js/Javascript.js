
        // تغییر حالت تاریک/روشن
        const themeToggle = document.getElementById('themeToggle');
        const themeIcon = document.getElementById('themeIcon');
        const htmlElement = document.documentElement;
        
        // بررسی theme ذخیره شده
        const savedTheme = localStorage.getItem('shopTheme') || 'light';
        setTheme(savedTheme);
        
        themeToggle.addEventListener('click', () => {
            const newTheme = htmlElement.getAttribute('data-bs-theme') === 'dark' ? 'light' : 'dark';
            setTheme(newTheme);
            localStorage.setItem('shopTheme', newTheme);
        });
        
        function setTheme(theme) {
            htmlElement.setAttribute('data-bs-theme', theme);
            themeIcon.className = theme === 'dark' ? 'bi bi-sun' : 'bi bi-moon';
        }
        
        // مدیریت سایدبار در موبایل
        const sidebar = document.getElementById('shopSidebar');
        const overlay = document.getElementById('mobileOverlay');
        const mobileToggle = document.getElementById('mobileSidebarToggle');
        const closeSidebarBtn = document.getElementById('closeSidebar');
        
        mobileToggle.addEventListener('click', () => {
            sidebar.classList.add('show');
            overlay.classList.add('show');
        });
        
        closeSidebarBtn.addEventListener('click', closeSidebar);
        overlay.addEventListener('click', closeSidebar);
        
        function closeSidebar() {
            sidebar.classList.remove('show');
            overlay.classList.remove('show');
        }
        
        // اسلایدر قیمت
        const priceSlider = document.getElementById('priceRange');
        const priceValue = document.getElementById('priceValue');
        
        priceSlider.addEventListener('input', function() {
            const value = parseInt(this.value).toLocaleString('fa-IR');
            priceValue.textContent = `${value} تومان`;
        });
        
        // انتخاب رنگ
        const colorOptions = document.querySelectorAll('.color-option');
        colorOptions.forEach(option => {
            option.addEventListener('click', function() {
                colorOptions.forEach(opt => opt.classList.remove('active'));
                this.classList.add('active');
            });
        });
        
        // تایمر تخفیف ویژه
        function updateCountdown() {
            const countdownElement = document.getElementById('countdown');
            let time = 23 * 60 * 60 + 59 * 60 + 59; // 23:59:59
            
            function formatTime(seconds) {
                const h = Math.floor(seconds / 3600);
                const m = Math.floor((seconds % 3600) / 60);
                const s = seconds % 60;
                return `${h.toString().padStart(2, '0')}:${m.toString().padStart(2, '0')}:${s.toString().padStart(2, '0')}`;
            }
            
            function tick() {
                time--;
                if (time < 0) {
                    time = 23 * 60 * 60 + 59 * 60 + 59; // ریست تایمر
                }
                countdownElement.textContent = formatTime(time);
            }
            
            tick(); // اجرای اولیه
            setInterval(tick, 1000);
        }
        
        updateCountdown();
        
        // افزودن به سبد خرید
        const addToCartButtons = document.querySelectorAll('.btn-add-to-cart');
        addToCartButtons.forEach(button => {
            button.addEventListener('click', function() {
                const productName = this.closest('.product-card').querySelector('.card-title').textContent;
                
                // شبیه‌سازی افزودن به سبد
                const cartBadge = document.querySelector('.cart-count');
                let count = parseInt(cartBadge.textContent);
                cartBadge.textContent = count + 1;
                
                // نمایش اعلان
                const toast = document.createElement('div');
                toast.className = 'position-fixed bottom-0 start-0 m-3 p-3 bg-success text-white rounded shadow';
                toast.style.zIndex = '1050';
                toast.innerHTML = `
                    <i class="bi bi-check-circle me-2"></i>
                    ${productName} به سبد خرید اضافه شد
                `;
                document.body.appendChild(toast);
                
                setTimeout(() => {
                    toast.remove();
                }, 3000);
            });
        });
        
        // انیمیشن اسکرول
        const fadeElements = document.querySelectorAll('.fade-in-up');
        
        function checkFade() {
            fadeElements.forEach(element => {
                const elementTop = element.getBoundingClientRect().top;
                const windowHeight = window.innerHeight;
                
                if (elementTop < windowHeight - 100) {
                    element.style.animationPlayState = 'running';
                }
            });
        }
        
        window.addEventListener('scroll', checkFade);
        window.addEventListener('load', checkFade);
    