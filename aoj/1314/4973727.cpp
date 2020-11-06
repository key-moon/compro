// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1314/judge/4973727/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

//BEGIN CUT HERE
template<typename T, T MOD = 1000000007>
struct Mint{
  static constexpr T mod = MOD;
  T v;
  Mint():v(0){}
  Mint(signed v):v(v){}
  Mint(long long t){v=t%MOD;if(v<0) v+=MOD;}

  Mint pow(long long k){
    Mint res(1),tmp(v);
    while(k){
      if(k&1) res*=tmp;
      tmp*=tmp;
      k>>=1;
    }
    return res;
  }

  static Mint add_identity(){return Mint(0);}
  static Mint mul_identity(){return Mint(1);}

  Mint inv(){return pow(MOD-2);}

  Mint& operator+=(Mint a){v+=a.v;if(v>=MOD)v-=MOD;return *this;}
  Mint& operator-=(Mint a){v+=MOD-a.v;if(v>=MOD)v-=MOD;return *this;}
  Mint& operator*=(Mint a){v=1LL*v*a.v%MOD;return *this;}
  Mint& operator/=(Mint a){return (*this)*=a.inv();}

  Mint operator+(Mint a) const{return Mint(v)+=a;}
  Mint operator-(Mint a) const{return Mint(v)-=a;}
  Mint operator*(Mint a) const{return Mint(v)*=a;}
  Mint operator/(Mint a) const{return Mint(v)/=a;}

  Mint operator-() const{return v?Mint(MOD-v):Mint(v);}

  bool operator==(const Mint a)const{return v==a.v;}
  bool operator!=(const Mint a)const{return v!=a.v;}
  bool operator <(const Mint a)const{return v <a.v;}

  static Mint comb(long long n,int k){
    Mint num(1),dom(1);
    for(int i=0;i<k;i++){
      num*=Mint(n-i);
      dom*=Mint(i+1);
    }
    return num/dom;
  }
};
template<typename T, T MOD> constexpr T Mint<T, MOD>::mod;
template<typename T, T MOD>
ostream& operator<<(ostream &os,Mint<T, MOD> m){os<<m.v;return os;}
//END CUT HERE

//BEGIN CUT HERE
template<typename K>
struct Matrix{
  typedef vector<K> arr;
  typedef vector<arr> mat;
  size_t r, c;
  mat dat;

  Matrix(){}
  Matrix(size_t r,size_t c):dat(r,arr(c,K())),r(r),c(c){}
  Matrix(mat dat):dat(dat),r(dat.size()),c(dat[0].size()){}

  size_t size() const{return dat.size();}
  bool empty() const{return size()==0;}
  arr& operator[](size_t k){return dat[k];}
  const arr& operator[](size_t k) const {return dat[k];}

  const void operator+=(Matrix<K>& b){
    for (int i = 0; i < r; i++){
      for (int j = 0; j < c; j++){
        dat[i][j] += b[i][j];
      }
    }
  }
  const Matrix<K> operator+(Matrix<K>& b){
    var res = Matrix<K>(dat);
    res += b;
    return res;
  }
  const void operator-=(Matrix<K>& b){
    for (int i = 0; i < r; i++){
      for (int j = 0; j < c; j++){
        dat[i][j] -= b[i][j];
      }
    }
  }
  const Matrix<K> operator-(Matrix<K>& b){
    var res = Matrix<K>(dat);
    res -= b;
    return res;
  }

  const void operator*=(K& b){
    for (int i = 0; i < r; i++){
      for (int j = 0; j < c; j++){
        dat[i][j] *= b;
      }
    }
  }

  static Matrix cross(const Matrix &A,const Matrix &B){
    Matrix res(A.size(),B[0].size());
    for(int i=0;i<(int)A.size();i++)
      for(int j=0;j<(int)B[0].size();j++)
        for(int k=0;k<(int)B.size();k++)
          res[i][j]+=A[i][k]*B[k][j];
    return res;
  }



  Matrix<K> transpose(){
    Matrix<K> res(c, r);
    for (int i = 0; i < r; i++){
      for (int j = 0; j < c; j++){
        res[j][i] = dat[i][j];
      }
    }
    return res;
  }
};
//END CUT HERE

using M = Mint<int, 32768>;
using Mat = Matrix<M>;

map<char, Mat> mats;

//A = expr
pair<char, Mat> assignment(string&, int&);
//term+term-term+...
Mat expr(string&, int&);
//primary*primary*...
Mat term(string&, int&);
//---...
//num/variable/matrix
//(transposed or indexed)...
Mat primary(string&, int&);
Mat matrix(string&, int&);

pair<char, Mat> assignment(string& s, int& i){
  assert(isalpha(s[i]));
  var variable = s[i];
  i++;
  assert(s[i] == '=');
  i++;
  var value = expr(s, i);
  return pair<char, Mat>(variable, value);
}

Mat expr(string& s, int& i){
  var res = term(s, i);
  while (i < s.size() && (s[i] == '+' || s[i] == '-')){
    var op = s[i];
    i++;
    var nxt = term(s, i);
    res = op == '+' ? res + nxt : res - nxt;
  }
  return res;
}

Mat term(string& s, int& i){
  var res = primary(s, i);
  while (i < s.size() && s[i] == '*'){
    i++;
    var nxt = primary(s, i);
    if (res.r == 1 && res.c == 1){
      nxt *= res.dat[0][0];
      res = nxt;
    }
    else if (nxt.r == 1 && nxt.c == 1){
      res *= nxt.dat[0][0];
    }
    else res = Mat::cross(res, nxt);
  }
  return res;
}

Mat primary(string& s, int& i){
  ll sign = 1;
  while (s[i] == '-'){
    sign *= -1;
    i++;
  }
  Mat res;
  if (isdigit(s[i])){
    ll num = 0;
    while (i < s.size() && isdigit(s[i])){
      num = num * 10 + s[i] - '0';
      i++;
    }
    res = Mat(1, 1);
    res[0][0] = M(num);
  }
  else if (isalpha(s[i])){
    res = mats[s[i]];
    i++;
  }
  else if (s[i] == '('){
    i++;
    res = expr(s, i);
    assert(s[i] == ')'); i++;
  }
  else{
    res = matrix(s, i);
  }
  while (i < s.size()){
    //O(nm) 100*100
    if (s[i] == '\''){
      res = res.transpose();
      i++;
      continue;
    }
    if (s[i] == '('){
      i++;
      var a = expr(s, i);
      assert(s[i] == ','); i++;
      var b = expr(s, i);
      assert(s[i] == ')'); i++;
      assert(a.r == 1 && b.r == 1);

      Mat k(a.c, b.c);
      for (int i = 0; i < k.r; i++){
        for (int j = 0; j < k.c; j++){
          k[i][j] = res[a[0][i].v - 1][b[0][j].v - 1];
        }
      }

      res = k;
      continue;
    }
    break;
  }
  for (int i = 0; i < res.r; i++){
    for (int j = 0; j < res.c; j++){
      res[i][j] = res[i][j] * M(sign);
    }
  }
  return res;
}

Mat matrix(string& s, int& i){
  assert(s[i] == '['); i++;
  vector<vector<M>> res;
  while (true){
    int baserow = -1;
    bool isfirst = true;
    while (true){
      var row = expr(s, i);
      if (isfirst){
        baserow = res.size();
        for (int i = 0; i < row.r; i++){
          res.push_back(vector<M>{});
        }
        isfirst = false;
      }
      for (int i = 0; i < row.r; i++){
        for (int j = 0; j < row.c; j++){
          res[baserow + i].emplace_back(row[i][j]);
        }
      }
      if (s[i] == ' '){
        i++;
        continue;
      }
      else break;
    }
    if (s[i] == ';'){
      i++;
      continue;
    }
    else break;
  }
  assert(s[i] == ']'); i++;
  return res;
}

void dump(Mat m){
  for (int i = 0; i < m.r; i++){
    for (int j = 0; j < m.c; j++){
      if (j != 0) cout << " ";
      cout << m[i][j];
    }
    cout << endl;
  }
}

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n;
  while (cin >> n, n){
    cin.ignore();
    for (int iter = 0; iter < n; iter++){
      string s;
      getline(cin, s);
      int i = 0;
      var [variable, value] = assignment(s, i);
      dump(value);
      mats[variable] = value;
    }
    cout << "-----" << endl;
  }
  return 0;
}

