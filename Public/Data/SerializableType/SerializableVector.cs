using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


namespace ResourceDataManagementLib.SerializableType
{
    public struct SerializableVector2
    {
        public float X, Y;


        public SerializableVector2(in Vector2 vector)
        {
            X = vector.x;
            Y = vector.y;
        }
        public SerializableVector2(in float x, in float y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Vector2(in SerializableVector2 serializableVector)
        {
            return new Vector2(serializableVector.X, serializableVector.Y);
        }
        public static implicit operator SerializableVector2(in Vector2 vector)
        {
            return new SerializableVector2(vector);
        }

        public static SerializableVector2 zero
        {
            get
            {
                return new SerializableVector2(0, 0);
            }
        }
        public static SerializableVector2 one
        {
            get
            {
                return new SerializableVector2(1, 1);
            }
        }
    }
    public struct SerializableVector3
    {
        public float X, Y, Z;


        public SerializableVector3(in Vector3 vector)
        {
            X = vector.x;
            Y = vector.y;
            Z = vector.z;
        }
        public SerializableVector3(in float x, in float y, in float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3(in SerializableVector3 serializableVector)
        {
            return new Vector3(serializableVector.X, serializableVector.Y, serializableVector.Z);
        }
        public static implicit operator SerializableVector3(in Vector3 vector)
        {
            return new SerializableVector3(vector);
        }

        public static SerializableVector3 zero
        {
            get
            {
                return new SerializableVector3(0, 0, 0);
            }
        }
        public static SerializableVector3 one
        {
            get
            {
                return new SerializableVector3(1, 1, 1);
            }
        }
    }
    public struct SerializableVector4
    {
        public float X, Y, Z, W;


        public SerializableVector4(in Vector4 vector)
        {
            X = vector.x;
            Y = vector.y;
            Z = vector.z;
            W = vector.w;
        }
        public SerializableVector4(in float x, in float y, in float z, in float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator Vector4(in SerializableVector4 serializableVector)
        {
            return new Vector4(serializableVector.X, serializableVector.Y, serializableVector.Z, serializableVector.W);
        }
        public static implicit operator SerializableVector4(in Vector4 vector)
        {
            return new SerializableVector4(vector);
        }

        public static SerializableVector4 zero
        {
            get
            {
                return new SerializableVector4(0, 0, 0, 0);
            }
        }
        public static SerializableVector4 one
        {
            get
            {
                return new SerializableVector4(1, 1, 1, 1);
            }
        }
    }
}