import datalayer from "./datalayer.js"

export default class ViewModel {
    constructor(brandId) {
        this.brandId = brandId
        this.template = document.querySelector('#car-template')
        this.target = document.querySelector('#cars')
        datalayer.getCarsByBrandId(this.brandId).then(cars => {
            for (const c of cars) {
                this.addCarToUi(c)
            }
        })
 
        document.querySelector("#add-car").addEventListener('click', () => {
            const newCar = {
                BrandId: this.brandId,
                Id: 0,
                Name: document.querySelector('#new-car-name').value,
                Price: document.querySelector('#new-car-price').value
            }
            datalayer.insertCar(newCar).then(c=>this.addCarToUi(c))
        })
    }

    addCarToUi(car) {
        this.template.content.querySelector('.car-name').textContent = car.Name
        this.template.content.querySelector('.car-price').textContent = car.Price

        const clone = document.importNode(this.template.content, true)
        this.target.appendChild(clone)
    }
}