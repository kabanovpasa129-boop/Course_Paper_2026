// Данные для портфолио
var portfolioItems = [
    { 
        title: "Логотип для «Альфа Банк»", 
        desc: "Современный минимализм", 
        img: "alfa.png" 
    },
    { 
        title: "Наружная реклама «Магнит»", 
        desc: "Баннер 3х6", 
        img: "magnit.png" 
    },
    { 
        title: "Сайт-визитка для стоматологии", 
        desc: "Разработка и дизайн", 
        img: "dental.jpg" 
    },
    { 
        title: "Фирменный стиль «Краснодар Парк»", 
        desc: "Айдентика полного цикла", 
        img: "kr.png" 
    },
    { 
        title: "Таргет для интернет-магазина", 
        desc: "Реклама ВКонтакте", 
        img: "vk.png" 
    },
    { 
        title: "Буклеты для выставки", 
        desc: "Дизайн и печать", 
        img: "file.jpg" 
    }
];

// Загрузка портфолио
document.addEventListener('DOMContentLoaded', function() {
    var portfolioGrid = document.getElementById('portfolioGrid');
    if (portfolioGrid) {
        for (var i = 0; i < portfolioItems.length; i++) {
            var item = portfolioItems[i];
            var card = document.createElement('div');
            card.className = 'portfolio-card';
            card.innerHTML = '<img src="' + item.img + '" alt="' + item.title + '">' +
                '<h3>' + item.title + '</h3>' +
                '<p>' + item.desc + '</p>';
            portfolioGrid.appendChild(card);
        }
    }

    var scrollToFormBtn = document.getElementById('scrollToFormBtn');
    if (scrollToFormBtn) {
        scrollToFormBtn.addEventListener('click', function() {
            document.getElementById('form').scrollIntoView({ behavior: 'smooth' });
        });
    }
});

// Отправка заявки
var form = document.getElementById('applicationForm');
var formMessage = document.getElementById('formMessage');

if (form) {
    form.onsubmit = function(e) {
        e.preventDefault();

        var projectName = document.getElementById('projectName').value;
        var fullName = document.getElementById('fullName').value;
        var phone = document.getElementById('phone').value;
        var preferences = document.getElementById('preferences').value;

        if (!projectName || !fullName || !phone) {
            formMessage.textContent = 'Заполните обязательные поля (название дела, ФИО, телефон)';
            formMessage.style.color = '#ff6b4a';
            return;
        }

        var nameParts = fullName.trim().split(' ');
        var lastName = nameParts[0] || '';
        var firstName = nameParts[1] || '';
        var middleName = nameParts[2] || '';

        var applicationData = {
            фамилия: lastName,
            имя: firstName,
            отчество: middleName,
            телефон: phone,
            комментарий: 'Название дела: ' + projectName + '\nПредпочтения: ' + preferences
        };

        formMessage.textContent = 'Отправка...';
        formMessage.style.color = 'white';

        // ОТПРАВКА НА СЕРВЕР
        fetch('http://localhost:5000/api/заявка', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(applicationData)
        })
        .then(function(response) {
            if (!response.ok) {
                throw new Error('Ошибка сервера');
            }
            return response.json();
        })
        .then(function(data) {
            formMessage.textContent = 'Спасибо! Ваша заявка отправлена. Мы свяжемся с вами в ближайшее время.';
            formMessage.style.color = '#4caf50';
            form.reset();
            setTimeout(function() {
                formMessage.textContent = '';
            }, 5000);
        })
        .catch(function(error) {
            formMessage.textContent = 'Ошибка при отправке. Попробуйте позже.';
            formMessage.style.color = '#ff6b4a';
            console.error('Error:', error);
        });
    };
}

// Навигация (плавная прокрутка)
var navLinks = document.querySelectorAll('.nav-link');
for (var i = 0; i < navLinks.length; i++) {
    navLinks[i].addEventListener('click', function(e) {
        e.preventDefault();
        var targetId = this.getAttribute('href').substring(1);
        var targetElement = document.getElementById(targetId);
        if (targetElement) {
            targetElement.scrollIntoView({ behavior: 'smooth' });
        }
    });
}