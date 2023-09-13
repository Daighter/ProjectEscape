using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGridSocket : XRSocketInteractor
{
    [SerializeField]
    int m_GridWidth = 2;
    public int gridWidth
    {
        get => m_GridWidth;
        set => m_GridWidth = Mathf.Max(1, value);
    }

    [SerializeField]
    int m_GridHeight = 2;
    public int gridHeight
    {
        get => m_GridHeight;
        set => m_GridHeight = Mathf.Max(1, value);
    }

    public int gridSize => m_GridWidth * m_GridHeight;

    [SerializeField]
    Vector2 m_CellOffset = new Vector2(0.1f, 0.1f);
    public Vector2 cellOffset
    {
        get => m_CellOffset;
        set => m_CellOffset = value;
    }

    readonly HashSet<Transform> m_UnorderedUsedAttachedTransform = new HashSet<Transform>();
    readonly Dictionary<IXRInteractable, Transform> m_UsedAttachTransformByInteractable =
        new Dictionary<IXRInteractable, Transform>();

    Transform[,] m_Grid;
    bool hasEmptyAttachTransform => m_UnorderedUsedAttachedTransform.Count < gridSize;

    protected override void Awake()
    {
        base.Awake();
        CreateGrid();
        interactableCantHoverMeshMaterial = interactableHoverMeshMaterial;
    }

    public void CreateGrid()
    {
        m_Grid = new Transform[m_GridHeight, m_GridWidth];

        for (var i = 0; i < m_GridHeight; i++)
        {
            for (var j = 0; j < m_GridWidth; j++)
            {
                var attachTransformInstance = new GameObject($"[{gameObject.name}] Attach ({i},{j})").transform;
                attachTransformInstance.SetParent(attachTransform, false);

                var offset = new Vector3(j * m_CellOffset.x, i * m_CellOffset.y, 0f);
                attachTransformInstance.localPosition = offset;

                m_Grid[i, j] = attachTransformInstance;
            }
        }
    }

    protected virtual void OnValidate()
    {
        m_GridWidth = Mathf.Max(1, m_GridWidth);
        m_GridHeight = Mathf.Max(1, m_GridHeight);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.matrix = attachTransform != null ? attachTransform.localToWorldMatrix : transform.localToWorldMatrix;
        for (var i = 0; i < m_GridHeight; i++)
        {
            for (var j = 0; j < m_GridWidth; j++)
            {
                var currentPosition = new Vector3(j * m_CellOffset.x, i * m_CellOffset.y, 0f);
                Gizmos.DrawLine(currentPosition + (Vector3.left * m_CellOffset.x * 0.5f), currentPosition + (Vector3.right * m_CellOffset.y * 0.5f));
                Gizmos.DrawLine(currentPosition + (Vector3.down * m_CellOffset.x * 0.5f), currentPosition + (Vector3.up * m_CellOffset.y * 0.5f));
            }
        }
    }

    /// <inheritdoc />
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        var closestAttachTransform = GetAttachTransform(args.interactableObject);
        m_UnorderedUsedAttachedTransform.Add(closestAttachTransform);
        m_UsedAttachTransformByInteractable.Add(args.interactableObject, closestAttachTransform);
    }

    /// <inheritdoc />
    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        var closestAttachTransform = m_UsedAttachTransformByInteractable[args.interactableObject];
        m_UnorderedUsedAttachedTransform.Remove(closestAttachTransform);
        m_UsedAttachTransformByInteractable.Remove(args.interactableObject);

        base.OnSelectExiting(args);
    }

    /// <inheritdoc />
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return IsSelecting(interactable)
               || (hasEmptyAttachTransform && !interactable.isSelected && !m_UnorderedUsedAttachedTransform.Contains(GetAttachTransform(interactable)));
    }

    /// <inheritdoc />
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable)
               && !m_UnorderedUsedAttachedTransform.Contains(GetAttachTransform(interactable));
    }

    /// <inheritdoc />
    public override Transform GetAttachTransform(IXRInteractable interactable)
    {
        if (m_UsedAttachTransformByInteractable.TryGetValue(interactable, out var interactableAttachTransform))
            return interactableAttachTransform;

        var interactableLocalPosition = attachTransform.InverseTransformPoint(interactable.GetAttachTransform(this).position);
        var i = Mathf.RoundToInt(interactableLocalPosition.y / m_CellOffset.y);
        var j = Mathf.RoundToInt(interactableLocalPosition.x / m_CellOffset.x);
        i = Mathf.Clamp(i, 0, m_GridHeight - 1);
        j = Mathf.Clamp(j, 0, m_GridWidth - 1);
        return m_Grid[i, j];
    }
}
