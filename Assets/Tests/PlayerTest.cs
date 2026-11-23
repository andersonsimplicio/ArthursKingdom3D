using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    private GameObject playerObject;
    private Player player;

    [SetUp] 
    public void Setup()
    {
        playerObject = new GameObject("TestPlayer");
        playerObject.AddComponent<CharacterController>();
        player = playerObject.AddComponent<Player>();
    }   

    [TearDown] 
    public void TearDown()
    {
        if (playerObject != null)
        {
            Object.Destroy(playerObject);
        }
    }

    [UnityTest]
    public IEnumerator Start_QuandoIncia_DefineSingletonEVelocidadePadrao()
    {
        yield return null;

        Assert.AreEqual(player, Player.Instance);
        Assert.AreEqual(3.0f, player._movimentSpeed);
        Assert.IsFalse(player.isPause);
    }

    [UnityTest]
    public IEnumerator Update_QuandoIsPauseVerdadeiro_NaoAlteraPosicaoDoJogador()
    {
        yield return null;

        player.isPause = true;
        Vector3 posicaoInicial = playerObject.transform.position;

        yield return null;
        yield return null;

        Assert.AreEqual(posicaoInicial, playerObject.transform.position);
    }

    [Test]
    public void MovimentSpeed_QuandoAlteradoPelaPropriedade_AtualizaValor()
    {
        player._movimentSpeed = 7.5f;

        Assert.AreEqual(7.5f, player._movimentSpeed);
    }
}