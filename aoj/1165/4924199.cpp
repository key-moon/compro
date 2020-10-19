// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1165/judge/4924199/C++17
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  int n;
  cin >> n;
  if (n == 0) return 0;
  using P = pair<int, int>;
  vector<P> ps{};
  ps.push_back(P(0, 0));
  int mny = 0, mnx = 0, mxy = 0, mxx = 0;
  for (int i = 1; i < n; i++){
    int a; int c;
    cin >> a >> c;
    var [y, x] = ps[a];
    int ny = y, nx = x;
    if (c == 0) nx--;
    if (c == 1) ny--;
    if (c == 2) nx++;
    if (c == 3) ny++;
    chmin(mny, ny);
    chmin(mnx, nx);
    chmax(mxy, ny);
    chmax(mxx, nx);
    ps.emplace_back(ny, nx);
  }
  cout << (mxx - mnx + 1) << " " << (mxy - mny + 1) << endl;
  main();
}

