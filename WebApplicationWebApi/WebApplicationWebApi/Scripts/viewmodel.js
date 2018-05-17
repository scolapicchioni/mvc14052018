import datalayer from "./datalayer.js"
export default class ViewModel {
    constructor(playerId) {
        this.container = document.querySelector("#games-container")
        this.template = document.querySelector("#game-template")
        this.gameNameElement = this.template.content.querySelector(".game-name")

        datalayer.getGamesByPlayerId(playerId).then(games => {
            for (const item of games) {
                this.addUiGame(item)
            }
        })

        document.getElementById("add-game").addEventListener("click", async () => {
            const game = {
                Id: 0,
                PlayerId: playerId,
                Name: document.getElementById("new-game-name").value
            }
            const newGame = await datalayer.addGame(game)
            this.addUiGame(newGame)
        })
    }

    addUiGame(item) {
        this.gameNameElement.textContent = item.Name
        const clone = document.importNode(this.template.content, true)
        this.container.appendChild(clone)
    }

}