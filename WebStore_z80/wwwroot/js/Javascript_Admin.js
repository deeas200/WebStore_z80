
        // تغییر حالت تاریک/روشن
        const themeToggle = document.getElementById('themeToggle');
        const themeIcon = document.getElementById('themeIcon');
        const htmlElement = document.documentElement;
        
        // بررسی ذخیره‌شده در localStorage
        const currentTheme = localStorage.getItem('theme') || 'light';
        setTheme(currentTheme);
        
        themeToggle.addEventListener('click', () => {
            const newTheme = htmlElement.getAttribute('data-bs-theme') === 'dark' ? 'light' : 'dark';
            setTheme(newTheme);
            localStorage.setItem('theme', newTheme);
        });
        
        function setTheme(theme) {
            htmlElement.setAttribute('data-bs-theme', theme);
            themeIcon.className = theme === 'dark' ? 'bi bi-sun' : 'bi bi-moon';
        }
        
        // مدیریت سایدبار در موبایل
        const sidebar = document.getElementById('sidebar');
        const overlay = document.getElementById('overlay');
        const closeSidebar = document.getElementById('closeSidebar');
        const sidebarToggle = document.querySelector('.sidebar-toggle');
        
        sidebarToggle.addEventListener('click', () => {
            sidebar.classList.add('show');
            overlay.classList.add('show');
        });
        
        closeSidebar.addEventListener('click', closeSidebarFunc);
        overlay.addEventListener('click', closeSidebarFunc);
        
        function closeSidebarFunc() {
            sidebar.classList.remove('show');
            overlay.classList.remove('show');
        }
        
        // رسم نمودار با Chart.js
        const ctx = document.getElementById('chart').getContext('2d');
        const chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور'],
                datasets: [{
                    label: 'فروش (میلیون تومان)',
                    data: [12, 19, 8, 15, 22, 18],
                    borderColor: '#0d6efd',
                    backgroundColor: 'rgba(13, 110, 253, 0.1)',
                    borderWidth: 2,
                    fill: true,
                    tension: 0.4
                }, {
                    label: 'کاربران (هزار نفر)',
                    data: [5, 10, 6, 12, 8, 15],
                    borderColor: '#198754',
                    backgroundColor: 'rgba(25, 135, 84, 0.1)',
                    borderWidth: 2,
                    fill: true,
                    tension: 0.4
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                        rtl: true
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        grid: {
                            color: 'rgba(0, 0, 0, 0.05)'
                        }
                    },
                    x: {
                        grid: {
                            color: 'rgba(0, 0, 0, 0.05)'
                        }
                    }
                }
            }
        });
        
        // تغییر خودکار رنگ کارت‌ها در حالت تاریک
        function updateCardColors() {
            const isDark = htmlElement.getAttribute('data-bs-theme') === 'dark';
            const cards = document.querySelectorAll('.custom-card');
            
            cards.forEach(card => {
                if (!card.classList.contains('bg-primary') && 
                    !card.classList.contains('bg-success') && 
                    !card.classList.contains('bg-warning') && 
                    !card.classList.contains('bg-info')) {
                    if (isDark) {
                        card.classList.add('bg-dark', 'text-white');
                    } else {
                        card.classList.remove('bg-dark', 'text-white');
                    }
                }
            });
        }
        
        // مشاهده تغییرات theme
        const observer = new MutationObserver(updateCardColors);
        observer.observe(htmlElement, { 
            attributes: true, 
            attributeFilter: ['data-bs-theme'] 
        });
        
        // اجرای اولیه
        updateCardColors();
    