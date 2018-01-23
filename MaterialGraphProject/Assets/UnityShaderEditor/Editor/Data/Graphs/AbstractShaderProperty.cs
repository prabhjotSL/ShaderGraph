using System;
using UnityEditor.Graphing;
using UnityEngine;

namespace UnityEditor.ShaderGraph
{
    [Serializable]
    public abstract class AbstractShaderProperty<T> : IShaderProperty
    {
        [SerializeField]
        private T m_Value;

        [SerializeField]
        private string m_DisplayName;

        [SerializeField]
        private string m_ReferenceName;

        [SerializeField]
        private bool m_GeneratePropertyBlock = true;

        [SerializeField]
        private SerializableGuid m_Guid = new SerializableGuid();

        public T value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        public string displayName
        {
            get
            {
                if (string.IsNullOrEmpty(m_DisplayName))
                    return guid.ToString();
                return m_DisplayName;
            }
            set { m_DisplayName = value; }
        }

        public string referenceName
        {
            get
            {
                if (string.IsNullOrEmpty(m_ReferenceName))
                    return string.Format("{0}_{1}", propertyType, GuidEncoder.Encode(guid));
                return m_ReferenceName;
            }
            set { m_ReferenceName = value; }
        }

        public abstract PropertyType propertyType { get; }

        public Guid guid
        {
            get { return m_Guid.guid; }
        }

        public bool generatePropertyBlock
        {
            get { return m_GeneratePropertyBlock; }
            set { m_GeneratePropertyBlock = value; }
        }

        public abstract Vector4 defaultValue { get; }
        public abstract string GetPropertyBlockString();
        public abstract string GetPropertyDeclarationString(string delimiter = ";");

        public virtual string GetPropertyAsArgumentString()
        {
            return GetPropertyDeclarationString(string.Empty);
        }

        public abstract PreviewProperty GetPreviewMaterialProperty();
        public abstract INode ToConcreteNode();
    }
}
