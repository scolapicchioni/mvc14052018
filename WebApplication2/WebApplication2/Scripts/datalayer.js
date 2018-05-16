const datalayer = {
    serviceUrl: '/api/cars',
    async getCarsByBrandId(id) {
        const res = await fetch('/api/brand/' + id + '/cars')
        return res.json()
    },
    async insertCar(car) {
        const res = await fetch(this.serviceUrl, {
            method: 'POST',
            body: JSON.stringify(car),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
        return res.json()
    }
}

export default datalayer