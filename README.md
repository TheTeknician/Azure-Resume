```markdown
# Azure-Resume  
My personal Azure-hosted resume project.  

## 🚀 **Overview**  
This project is part of the **Azure Resume Challenge**, where I created and deployed my resume on **Microsoft Azure**. The resume is built using **HTML**, **CSS**, and **JavaScript** and includes a visitor counter that tracks the number of views using an **Azure Function**.  

---

## 📁 **Project Structure**  
```bash
├── frontend/
│   ├── css/              # Contains styling files
│   ├── images/           # Contains image assets
│   ├── js/
│   │   └── main.js       # Handles visitor counter logic
│   ├── favicon/          # Contains favicon files
│   ├── index.html        # Main HTML file for the resume
├── README.md             # Project documentation
├── main.js               # Visitor counter logic
└── overview/             # Contains additional project details
```

---

## 🛠️ **Setup and Deployment**  
### 1. **Clone the Repository**  
```bash
git clone https://github.com/theteknician/Azure-Resume.git
cd Azure-Resume
```

### 2. **Set Up the Azure Function**  
- Create an **HTTP-triggered Azure Function**.  
- Set up CORS to allow requests from your frontend domain.  
- Deploy the function using Azure CLI or Visual Studio Code.  

### 3. **Deploy the Website**  
- Host the website using **Azure Static Web Apps** or **Azure Blob Storage** (with static website enabled).  
- Update the `functionApi` variable in `main.js` with your function URL.  

---

## 💡 **Key Features**  
### ✅ **Visitor Counter**  
The visitor counter is powered by an Azure Function that increments and returns the count of visits.  

### **Code Snippet:**  
```javascript
window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApi = '<YOUR_AZURE_FUNCTION_URL>';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApi).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}
```

---

## 🌐 **Technologies Used**  
- **HTML** – For structure and content  
- **CSS** – For styling  
- **JavaScript** – For dynamic content  
- **Azure Functions** – For serverless backend  
- **Azure Static Web Apps** – For deployment  

---

## 🎯 **Next Steps**  
- [ ] Improve CSS styling and layout  
- [ ] Add more backend functionality  
- [ ] Integrate CI/CD with GitHub Actions  

---

## 🏆 **Acknowledgements**  
- Inspired by the [Azure Resume Challenge](https://www.azureresume.com).  
```