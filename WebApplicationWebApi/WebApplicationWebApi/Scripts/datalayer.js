const datalayer = {
    async getGamesByPlayerId(playerId) {
        const response = await fetch('/api/player/' + playerId + '/games')
        if(response.status==200)
            return response.json()
    },
    async addGame(game) {
        const response = await fetch('/api/games', {
            method: 'POST',
            body: JSON.stringify(game),
            headers: new Headers({
                'Content-Type' : 'application/json'
            })
        })
        return response.json()
    }
}

export default datalayer