﻿using System;

namespace IFramework.Modules.ECS
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEnity
    {
        /// <summary>
        /// 注册的模块
        /// </summary>
         ECSModule _mou { get; set; }
        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IComponent GetComponent(Type type);
        /// <summary>
        /// 湖区组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetComponent<T>() where T : IComponent;
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
         IComponent AddComponent(Type type);
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
         T AddComponent<T>() where T : IComponent;
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
         IComponent AddComponent(IComponent component);
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
         T AddComponent<T>(T component) where T : IComponent;
        /// <summary>
        /// 移除组件
        /// </summary>
        /// <param name="type"></param>
         void RemoveComponent(Type type);

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
         void RemoveComponent<T>() where T : IComponent;
        /// <summary>
        /// 是否包含组件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
         bool ContainsComponent(Type type);
        /// <summary>
        /// 是否包含组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool ContainsComponent<T>() where T : IComponent;
        /// <summary>
        /// 直接替换原组件，结构体必须使用这个方法刷新数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="component"></param>
         void ReFreshComponent(Type type, IComponent component);
        /// <summary>
        /// 直接替换原组件，结构体必须使用这个方法刷新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
         void ReFreshComponent<T>(T component) where T : IComponent;
        /// <summary>
        /// 解除模块注册
        /// </summary>
         void Destory();
    }
    /// <summary>
    /// 实体
    /// </summary>
    public abstract class Enity: IEnity
    {
        /// <summary>
        /// 注册的模块
        /// </summary>
        public ECSModule _mou { get; set; }
        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IComponent GetComponent(Type type)
        {
            return _mou.GetComponent(this, type);
        }
        /// <summary>
        /// 湖区组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : IComponent
        {
            return (T)GetComponent(typeof(T));
        }
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IComponent AddComponent(Type type)
        {
            return _mou.AddComponent(this, type);
        }
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddComponent<T>() where T : IComponent
        {
            return (T)AddComponent(typeof(T));
        }
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public IComponent AddComponent(IComponent component)
        {
            return _mou.AddComponent(this, component);
        }
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        public T AddComponent<T>(T component) where T : IComponent
        {
            return AddComponent(component);
        }
        /// <summary>
        /// 移除组件
        /// </summary>
        /// <param name="type"></param>
        public void RemoveComponent(Type type)
        {
            _mou.RemoveComponent(this, type);
        }

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveComponent<T>() where T : IComponent
        {
            RemoveComponent(typeof(T));
        }
        /// <summary>
        /// 是否包含组件
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ContainsComponent(Type type)
        {
            return _mou.GetComponent(this, type) != null;
        }
        /// <summary>
        /// 是否包含组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool ContainsComponent<T>() where T : IComponent
        {
            return ContainsComponent(typeof(T));
        }
        /// <summary>
        /// 直接替换原组件，结构体必须使用这个方法刷新数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="component"></param>
        public void ReFreshComponent(Type type ,IComponent component)
        {
            _mou.ReFreshComponent(this, type, component);
        }
        /// <summary>
        /// 直接替换原组件，结构体必须使用这个方法刷新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public void ReFreshComponent<T>(T component)where T:IComponent
        {
            ReFreshComponent(typeof(T), component);
        }
        /// <summary>
        /// 解除模块注册
        /// </summary>
        public void Destory()
        {
          //  Log.E("dispose  " +GetType());

            OnDestory();
            if (_mou != null)
                _mou.UnSubscribeEnity(this);
        }
        /// <summary>
        /// 解除模块注册时调用
        /// </summary>
        protected virtual void OnDestory() { }
    }

}
