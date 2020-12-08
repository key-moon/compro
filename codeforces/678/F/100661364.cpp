// detail: https://codeforces.com/contest/678/submission/100661364
#include <bits/stdc++.h>
using namespace std;
using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

//BEGIN CUT HERE
enum Objective{
  MINIMIZE = +1,
  MAXIMIZE = -1,
};

template<typename T> struct Line {
  T k,m;
  T operator()(const T x)const{return k*x+m;}
};

template <typename T, Objective objective>
struct ConvexHullTrick : deque<Line<T>>{
  inline int sgn(T x){return x==0?0:(x<0?-1:1);}

  using D = long double;
  inline bool check(const Line<T> &a,const Line<T> &b,const Line<T> &c){
    if(b.m==a.m or c.m==b.m)
      return sgn(b.k-a.k)*sgn(c.m-b.m) >= sgn(c.k-b.k)*sgn(b.m-a.m);
    // return (b.k-a.k)*(c.m-b.m) >= (b.m-a.m)*(c.k-b.k);
    return
      D(b.k-a.k)*sgn(c.m-b.m)/D(abs(b.m-a.m)) >=
      D(c.k-b.k)*sgn(b.m-a.m)/D(abs(c.m-b.m));
  }

  using super = deque<Line<T>>;
  using super::empty,super::size,super::front,super::back;
  using super::emplace_front,super::emplace_back;
  using super::pop_front,super::pop_back;
  const Line<T> at(int i) const{return (*this)[i];}

  void add(T k_,T m_){
    Line<T> l({k_*objective,m_*objective});
    if(empty()){
      emplace_front(l);
      return;
    }
    if(front().k<=l.k){
      if(front().k==l.k){
        if(front().m<=l.m) return;
        pop_front();
      }
      while(size()>=2 and check(l,at(0),at(1))) pop_front();
      emplace_front(l);
    }else{
      assert(l.k<=back().k);
      if(back().k==l.k){
        if(back().m<=l.m) return;
        pop_back();
      }
      while(size()>=2 and check(at(size()-2),at(size()-1),l)) pop_back();
      emplace_back(l);
    }
  }

  T query(T x){
    assert(!empty());
    int l=-1,r=size()-1;
    while(l+1<r){
      int m=(l+r)>>1;
      if(at(m)(x)>=at(m+1)(x)) l=m;
      else r=m;
    }
    return at(r)(x)*objective;
  }

  T queryMonotoneInc(T x){
    assert(!empty());
    while(size()>=2 and at(0)(x)>=at(1)(x)) pop_front();
    return front()(x)*objective;
  }

  T queryMonotoneDec(T x){
    assert(!empty());
    while(size()>=2 and at(size()-1)(x)>=at(size()-2)(x)) pop_back();
    return back()(x)*objective;
  }
};
template<typename T>
using MinConvexHullTrick = ConvexHullTrick<T, Objective::MINIMIZE>;
template<typename T>
using MaxConvexHullTrick = ConvexHullTrick<T, Objective::MAXIMIZE>;

int main(){
  cin.tie(nullptr);
  ios::sync_with_stdio(false);
  int n;
  cin >> n;
  using P = pair<int, int>;
  vector<P> queries{};
  vector<P> addedLines{};
  vector<P> addedSection{};
  vector<int> indAt(n);
  for (int i = 0; i < n; i++){
    int t;
    cin >> t;
    if (t == 1){
      int k, m;
      cin >> k >> m;
      indAt[i] = addedSection.size();
      addedLines.emplace_back(k, m);
      addedSection.emplace_back(i, n);
    }
    if (t == 2){
      int ind;
      cin >> ind;
      addedSection[indAt[ind - 1]].second = i;
    }
    if (t == 3){
      int x;
      cin >> x;
      queries.emplace_back(i, x);
    }
  }
  
  int PACKET_SIZE = 512;
  vector<P> smallD{};
  vector<P> largeD{};
  for (int i = 0; i < addedLines.size(); i++){
    var [s, t] = addedSection[i];
    var [k, m] = addedLines[i];
    int ind = s;
    while (ind < t){
      if (ind % PACKET_SIZE == 0 && ind + PACKET_SIZE < t){
        largeD.emplace_back(ind / PACKET_SIZE, i);
        while (ind + PACKET_SIZE < t) ind += PACKET_SIZE;
        largeD.emplace_back(ind / PACKET_SIZE, ~i);
      }
      else{
        smallD.emplace_back(ind, i);
        ind = min((ind / PACKET_SIZE + 1) * PACKET_SIZE, t);
        smallD.emplace_back(ind, ~i);
      }
    }
  }
  
  sort(smallD.begin(), smallD.end());
  var sIter = smallD.begin();
  unordered_set<int> largeLineInds{};

  MaxConvexHullTrick<ll> cht{};
  sort(largeD.begin(), largeD.end());
  var lIter = largeD.begin();
  unordered_set<int> smallLineInds{};
  
  for (var [time, q] : queries){
    while (sIter != smallD.end()){
      var [t, lineInd] = *sIter;
      if (time < t) break;
      if (0 <= lineInd) smallLineInds.insert(lineInd);
      else smallLineInds.erase(~lineInd);
      sIter++;
    }
    bool changed = false;
    while (lIter != largeD.end()){
      var [t, lineInd] = *lIter;
      if (time < t * PACKET_SIZE) break;
      changed = true;
      if (0 <= lineInd) largeLineInds.insert(lineInd);
      else largeLineInds.erase(~lineInd);
      lIter++;
    }
    if (changed) {
      cht.clear();
      vector<P> lines{};
      for (var&& ind : largeLineInds) lines.emplace_back(addedLines[ind]);
      sort(lines.begin(), lines.end());
      for (var&& [k, m] : lines) cht.add(k, m);
    }
    
    ll mx = INT64_MIN;
    for (var&& ind : smallLineInds) {
      var [k, m] = addedLines[ind];
      chmax(mx, (ll)k * q + m);
    }
    if (!cht.empty()) chmax(mx, cht.query(q));

    if (mx == INT64_MIN) cout << "EMPTY SET" << newl;
    else cout << mx << newl;
  }
  return 0;
}
